using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public class KhachHang
        {
            public int MaKH { get; set; }
            public string TenKH { get; set; }
            public string SoDienThoai { get; set; }
            public string DiaChi { get; set; }
        }


        private BindingList<KhachHang> danhSachKhachHang = new BindingList<KhachHang>();

        private int nextMaKH = 1; // Tự động tăng mã khách hàng




        private void Form1_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = true; // Automatically create columns from data properties
            // Thiết lập các cột
            dgvKhachHang.Columns.Add("MaKH", "Mã KH");
            dgvKhachHang.Columns.Add("TenKH", "Tên Khách Hàng");
            dgvKhachHang.Columns.Add("SoDienThoai", "Số Điện Thoại");
            dgvKhachHang.Columns.Add("DiaChi", "Địa Chỉ");
        }


        // Sự kiện khi chọn một dòng trong DataGridView để hiển thị thông tin vào TextBox
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (e.RowIndex >= 0)
            {
                // Lấy khách hàng từ dòng được chọn
                KhachHang khachHang = danhSachKhachHang[e.RowIndex];

                // Hiển thị thông tin vào các TextBox
                txtTenKH.Text = khachHang.TenKH;
                txtSDT.Text = khachHang.SoDienThoai;
                txtDiaChi.Text = khachHang.DiaChi;

                // Lưu chỉ số của dòng đang chọn để sửa sau
                selectedIndex = e.RowIndex;
            }
        }

        // Biến lưu chỉ số của khách hàng đang được chọn để sửa
        private int selectedIndex = -1;

        // Sự kiện khi nhấn nút Sửa để cập nhật thông tin khách hàng
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có khách hàng nào đang được chọn không
            if (selectedIndex >= 0 && selectedIndex < danhSachKhachHang.Count)
            {
                // Cập nhật thông tin khách hàng trong danh sách
                danhSachKhachHang[selectedIndex].TenKH = txtTenKH.Text;
                danhSachKhachHang[selectedIndex].SoDienThoai = txtSDT.Text;
                danhSachKhachHang[selectedIndex].DiaChi = txtDiaChi.Text;

                // Cập nhật DataGridView
                CapNhatDanhSachKhachHang();

                // Đặt lại chỉ số dòng được chọn
                selectedIndex = -1;

                // Xóa trắng các TextBox sau khi sửa
                txtTenKH.Clear();
                txtSDT.Clear();
                txtDiaChi.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa.");
            }
        }


        public class DichVu
        {
            public int MaDV { get; set; }
            public string TenDV { get; set; }
            public decimal GiaTien { get; set; }
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng KhachHang mới từ dữ liệu nhập trong các TextBox
            KhachHang khachHang = new KhachHang
            {
                MaKH = nextMaKH++, // Mã khách hàng tự động tăng
                TenKH = txtTenKH.Text,
                SoDienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text
            };

            // Thêm khách hàng vào danh sách
            danhSachKhachHang.Add(khachHang);

            // Cập nhật DataGridView
            CapNhatDanhSachKhachHang();

            // Xóa trắng các TextBox sau khi thêm
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
        }

        // Phương thức để cập nhật DataGridView hiển thị danh sách khách hàng
        private void CapNhatDanhSachKhachHang()
        {
            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = danhSachKhachHang;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang được chọn trong DataGridView không
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                // Lấy chỉ số dòng được chọn
                int index = dgvKhachHang.SelectedRows[0].Index;

                // Xóa khách hàng từ danh sách dựa vào chỉ số dòng
                danhSachKhachHang.RemoveAt(index);

                // Cập nhật DataGridView
                CapNhatDanhSachKhachHang();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvKhachHang.SelectedRows[0].Index;
                KhachHang khachHang = danhSachKhachHang[selectedIndex];

                MessageBox.Show($"Mã KH: {khachHang.MaKH}\nTên KH: {khachHang.TenKH}\nSĐT: {khachHang.SoDienThoai}\nĐịa chỉ: {khachHang.DiaChi}", "Chi tiết khách hàng");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông báo");
            }
        }
    }
}
