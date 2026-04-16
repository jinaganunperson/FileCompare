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
                var files = Directory.EnumerateFiles(folderPath).Select(p => new FileInfo(p)).OrderBy(f => f.Name);
                foreach (var f in files)
                {
                    var item = new ListViewItem(f.Name);
                    item.SubItems.Add(FormatSizeInKb(f.Length));
                    item.SubItems.Add(f.LastWriteTime.ToString("g"));
                    item.Tag = f.LastWriteTime.Ticks; // 비교를 위해 원본 시간을 Tag에 저장
                    lv.Items.Add(item);
                }
            }
            catch (Exception ex) { MessageBox.Show("오류: " + ex.Message); }
            finally { lv.EndUpdate(); }
        }

        // ★ 양쪽 리스트뷰를 정밀 비교하여 색상을 입히는 핵심 함수
        private void CompareListViews()
        {
            if (lvwLeftDir.Items.Count == 0 || lvwRightDir.Items.Count == 0) return;

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
            if (target == null)
            {
                current.ForeColor = Color.Red; // 상대방에 없음 (독고다이)
            }
            else
            {
                long currentTime = (long)current.Tag;
                long targetTime = (long)target.Tag;

                if (currentTime == targetTime)
                {
                    current.ForeColor = Color.Black; // 동일 파일
                }
                else
                {
                    current.ForeColor = Color.Purple; // ★ 이름은 같은데 내용(시간)이 다름!
                }
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