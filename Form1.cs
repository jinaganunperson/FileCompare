using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // OwnerDraw는 직접 그릴 때만 사용하므로 false가 맞습니다.
            lvwLeftDir.OwnerDraw = false;
            lvwRightDir.OwnerDraw = false;
            // 복사 버튼 이벤트 연결
            btnCopyFromLeft.Click += btnCopyFromLeft_Click;
            btnCopyFromRight.Click += btnCopyFromRight_Click;
        }

        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            SelectFolder(txtLeftDir, lvwLeftDir);
        }

        private void btnRightDir_Click(object sender, EventArgs e)
        {
            SelectFolder(txtRightDir, lvwRightDir);
        }

        // 폴더 선택 공통 로직
        private void SelectFolder(TextBox txt, ListView lv)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (!string.IsNullOrWhiteSpace(txt.Text) && Directory.Exists(txt.Text))
                    dlg.SelectedPath = txt.Text;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txt.Text = dlg.SelectedPath;
                    PopulateListView(lv, dlg.SelectedPath);
                    // ★ 폴더를 선택할 때마다 양쪽을 다시 비교함
                    CompareListViews();
                }
            }
        }

        private void PopulateListView(ListView lv, string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath)) return;

            lv.BeginUpdate();
            lv.Items.Clear();

            try
            {
                // 먼저 하위 폴더를 목록에 추가 (폴더는 파일처럼 취급)
                var dirs = Directory.EnumerateDirectories(folderPath).Select(p => new DirectoryInfo(p)).OrderBy(d => d.Name);
                foreach (var d in dirs)
                {
                    var item = new ListViewItem(d.Name);
                    item.SubItems.Add("<DIR>");
                    item.SubItems.Add(d.LastWriteTime.ToString("g"));
                    item.Tag = new FileEntry { IsDirectory = true, TimeTicks = d.LastWriteTime.Ticks };
                    lv.Items.Add(item);
                }

                // 그 다음 일반 파일을 추가
                var files = Directory.EnumerateFiles(folderPath).Select(p => new FileInfo(p)).OrderBy(f => f.Name);
                foreach (var f in files)
                {
                    var item = new ListViewItem(f.Name);
                    item.SubItems.Add(FormatSizeInKb(f.Length));
                    item.SubItems.Add(f.LastWriteTime.ToString("g"));
                    item.Tag = new FileEntry { IsDirectory = false, TimeTicks = f.LastWriteTime.Ticks };
                    lv.Items.Add(item);
                }
            }
            catch (Exception ex) { MessageBox.Show("오류: " + ex.Message); }
            finally { lv.EndUpdate(); }
        }

        // ★ 양쪽 리스트뷰를 정밀 비교하여 색상을 입히는 핵심 함수
        private void CompareListViews()
        {
            // 둘 다 비어있으면 비교할 필요 없음
            if (lvwLeftDir.Items.Count == 0 && lvwRightDir.Items.Count == 0) return;

            lvwLeftDir.BeginUpdate();
            lvwRightDir.BeginUpdate();

            // 1. 왼쪽 기준 비교
            foreach (ListViewItem leftItem in lvwLeftDir.Items)
            {
                ListViewItem rightMatch = FindItem(lvwRightDir, leftItem.Text);
                SetItemColor(leftItem, rightMatch);
            }

            // 2. 오른쪽 기준 비교
            foreach (ListViewItem rightItem in lvwRightDir.Items)
            {
                ListViewItem leftMatch = FindItem(lvwLeftDir, rightItem.Text);
                SetItemColor(rightItem, leftMatch);
            }

            lvwLeftDir.EndUpdate();
            lvwRightDir.EndUpdate();
        }

        private void SetItemColor(ListViewItem current, ListViewItem target)
        {
            // 상대 항목이 없으면 단독 파일: 보라색
            if (target == null)
            {
                current.ForeColor = Color.Purple; // 단독 파일
                return;
            }

            // 둘 다 FileEntry 태그를 사용한다고 가정
            var curEntry = current.Tag as FileEntry;
            var tgtEntry = target.Tag as FileEntry;

            long currentTime = curEntry != null ? curEntry.TimeTicks : 0L;
            long targetTime = tgtEntry != null ? tgtEntry.TimeTicks : 0L;

            if (currentTime == targetTime)
            {
                current.ForeColor = Color.Black; // 동일 파일
                target.ForeColor = Color.Black;
            }
            else if (currentTime > targetTime)
            {
                // current가 newer
                current.ForeColor = Color.Red;   // newer는 빨간색
                target.ForeColor = Color.Gray;   // older는 회색
            }
            else
            {
                // current가 older
                current.ForeColor = Color.Gray;  // older는 회색
                target.ForeColor = Color.Red;    // newer는 빨간색
            }
        }

        private ListViewItem FindItem(ListView lv, string name)
        {
            foreach (ListViewItem item in lv.Items)
            {
                if (item.Text == name) return item;
            }
            return null;
        }

        private string FormatSizeInKb(long bytes)
        {
            return (bytes / 1024).ToString("N0") + " KB";
        }

        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            CopySelectedFiles(lvwLeftDir, txtLeftDir.Text, txtRightDir.Text);
        }

        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            CopySelectedFiles(lvwRightDir, txtRightDir.Text, txtLeftDir.Text);
        }

        // 선택한 파일들을 srcDir에서 dstDir로 복사하고 리스트뷰를 갱신
        private void CopySelectedFiles(ListView sourceListView, string srcDir, string dstDir)
        {
            if (string.IsNullOrWhiteSpace(srcDir) || !Directory.Exists(srcDir))
            {
                MessageBox.Show("원본 폴더가 유효하지 않습니다.");
                return;
            }
            if (string.IsNullOrWhiteSpace(dstDir) || !Directory.Exists(dstDir))
            {
                MessageBox.Show("대상 폴더가 유효하지 않습니다.");
                return;
            }
            if (sourceListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("복사할 파일을 선택하세요.");
                return;
            }

            foreach (ListViewItem item in sourceListView.SelectedItems)
            {
                string name = item.Text;
                var entry = item.Tag as FileEntry;
                string srcPath = Path.Combine(srcDir, name);
                string dstPath = Path.Combine(dstDir, name);

                try
                {
                    if (entry != null && entry.IsDirectory)
                    {
                        // 디렉터리인 경우 재귀적으로 복사
                        CopyDirectoryRecursive(srcPath, dstPath);
                    }
                    else
                    {
                        // 파일 복사 (덮어쓰기 허용)
                        File.Copy(srcPath, dstPath, true);
                        // 원본의 시간 정보를 대상에 복사
                        File.SetLastWriteTime(dstPath, File.GetLastWriteTime(srcPath));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"복사 오류: {name}\n{ex.Message}");
                }
            }

            // 양쪽 리스트뷰를 갱신하고 비교
            PopulateListView(lvwLeftDir, txtLeftDir.Text);
            PopulateListView(lvwRightDir, txtRightDir.Text);
            CompareListViews();
        }

        // 디렉터리를 재귀적으로 복사
        private void CopyDirectoryRecursive(string sourceDir, string targetDir)
        {
            if (!Directory.Exists(sourceDir)) throw new DirectoryNotFoundException(sourceDir);

            if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);

            // 파일 복사
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                var fileName = Path.GetFileName(file);
                var destFile = Path.Combine(targetDir, fileName);
                File.Copy(file, destFile, true);
                File.SetLastWriteTime(destFile, File.GetLastWriteTime(file));
            }

            // 하위 디렉터리 재귀 처리
            foreach (var dir in Directory.GetDirectories(sourceDir))
            {
                var dirName = Path.GetFileName(dir);
                var destSubDir = Path.Combine(targetDir, dirName);
                CopyDirectoryRecursive(dir, destSubDir);
                Directory.SetLastWriteTime(destSubDir, Directory.GetLastWriteTime(dir));
            }
            // 생성(또는 덮어쓰기) 후 최상위 대상 디렉터리의 수정시간을 원본과 동일하게 설정
            Directory.SetLastWriteTime(targetDir, Directory.GetLastWriteTime(sourceDir));
        }

        // 리스트뷰의 항목에 저장할 정보
        private class FileEntry
        {
            public bool IsDirectory { get; set; }
            public long TimeTicks { get; set; }
        }
        private void lvwLeftDir_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true; // 시스템이 기본적으로 그리도록 설정
        }

        // 혹시 오른쪽 리스트뷰(lvwRightDir)도 똑같은 오류가 난다면 이것도 추가하세요.
        private void lvwRightDir_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
    
        // 리스트뷰의 DrawItem 이벤트가 디자인 파일에 등록되어 있다면 이 메서드가 반드시 있어야 합니다.

    }