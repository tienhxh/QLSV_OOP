using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV_OOP.DAO;
using QLSV_OOP.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLSV_OOP
{
    public class CustomizeMenuStrip
    {
        private static CustomizeMenuStrip instance;

        public static CustomizeMenuStrip Instance
        {
            get
            {
                if (instance == null) instance = new CustomizeMenuStrip();
                return instance;
            }
            private set => instance = value;
        } 
        private CustomizeMenuStrip() { }

        SqlConnection con = new SqlConnection(ConnectionString.connectionString);
        SqlDataAdapter sda;
        public List<string> RetrieveRole(string roleid) 
        {
            List<string> itemsToDisplay = new List<string>();
            try
            {
                sda = new SqlDataAdapter("SELECT * FROM quyen WHERE MaQuyen ='" + roleid + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Dictionary<string, string> columnNamesMap = new Dictionary<string, string>()
                {
                    {"CapNhatDiem", "Cập nhật điểm"},
                    {"DangKyLop", "Đăng ký lớp"},
                    {"TraCuuTKB", "Tra cứu TKB"},
                    {"TraKQHT", "Tra cứu KQHT"},
                    {"CapNhatHB", "Cập nhật thông tin học bổng"},
                    {"PheDuyetHB", "Phê duyệt yêu cầu học bổng"},
                    {"DangKyHB", "Đăng ký học bổng"},
                    {"CapNhatTTTT", "Thông tin HTTT"},
                    {"CapNhatCongNo", "Cập nhật công nợ"},
                    {"KtraDuNo", "Kiểm tra dư nợ"},
                    {"TkeHocPhi", "Học phí"},
                    {"TkeNoHPhi", "Nợ đọng học phí"},
                    {"TkeDiem", "Điểm"},
                    {"TkeHB", "Học bổng"}
                };

                    foreach (var columnName in columnNamesMap.Keys)
                    {
                        bool columnValue = (bool)row[columnName];
                        if (dt.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                        {
                            if (columnValue)
                            {
                                if (columnNamesMap[columnName] == "Đăng ký lớp" || columnNamesMap[columnName] == "Cập nhật điểm"
                                    || columnNamesMap[columnName] == "Tra cứu TKB" || columnNamesMap[columnName] == "Tra cứu KQHT")
                                {
                                    itemsToDisplay.Add("Đào Tạo");
                                    itemsToDisplay.Add(columnNamesMap[columnName]);
                                }    
                                else if (columnNamesMap[columnName] == "Cập nhật thông tin học bổng" || 
                                    columnNamesMap[columnName] == "Phê duyệt yêu cầu học bổng" || columnNamesMap[columnName] == "Đăng ký học bổng")
                                {
                                    itemsToDisplay.Add("Học Bổng");
                                    itemsToDisplay.Add(columnNamesMap[columnName]);
                                }    
                                else if(columnNamesMap[columnName] == "Thông tin HTTT" || columnNamesMap[columnName] == "Cập nhật công nợ" || 
                                    columnNamesMap[columnName] == "Kiểm tra dư nợ")
                                {
                                    itemsToDisplay.Add("Tài Vụ");
                                    itemsToDisplay.Add(columnNamesMap[columnName]);
                                }
                                else
                                {
                                    itemsToDisplay.Add("Thống Kê");
                                    itemsToDisplay.Add(columnNamesMap[columnName]);
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
                return itemsToDisplay;
               
        }

        public void Customize(MenuStrip menuStrip, List<string> selectedItems)
        {
            List<ToolStripMenuItem> availableMenuItems = menuStrip.Items.OfType<ToolStripMenuItem>().ToList();

            List<ToolStripMenuItem> itemsToDisplay = new List<ToolStripMenuItem>();

            foreach (ToolStripMenuItem menuItem in availableMenuItems)
            {
                if (selectedItems.Contains(menuItem.Text))
                {
                    if (menuItem.DropDownItems.Count > 0)
                    {
                        ToolStripItem[] subItems = menuItem.DropDownItems.OfType<ToolStripItem>()
                            .Where(subItem => selectedItems.Contains(subItem.Text))
                            .ToArray();

                        if (subItems.Length > 0)
                        {
                            ToolStripMenuItem clonedMenuItem = new ToolStripMenuItem(menuItem.Text);
                            clonedMenuItem.DropDownItems.AddRange(subItems);
                            itemsToDisplay.Add(clonedMenuItem);
                        }
                    }
                    else
                    {
                        itemsToDisplay.Add(menuItem);
                    }
                }
            }

            menuStrip.Items.Clear();
            menuStrip.Items.AddRange(itemsToDisplay.ToArray());
        }

        public void CustomizeAccount(MenuStrip menuStrip, string fullName)
        {
            
            ToolStripMenuItem hoten = new ToolStripMenuItem("Xin chào " + fullName);
            ToolStripMenuItem changePassword = new ToolStripMenuItem("Thay đổi mật khẩu");
            ToolStripMenuItem signOut = new ToolStripMenuItem("Thoát");
            signOut.Click += FunctionMenuStrip.Instance.SignOut;
            
            hoten.DropDownItems.Add(changePassword);
            hoten.DropDownItems.Add(signOut);
            menuStrip.Items.Add(hoten);
           
        }

        




    }
}
