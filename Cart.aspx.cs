using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Cart : System.Web.UI.Page
{
    //Biến toàn cục lưu thông tin "Giỏ hàng" phải khai báo tĩnh : static
    static DataTable tbl = new DataTable();

    //CHẠY KHI TRANG WEB ĐƯỢC TẢI TRÊN TRÌNH DUYỆT: XEM GIỎ HÀNG
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["giohang"] == null)//Giỏ hàng "rổng"
        {
            lbTittle.Text = "GIỎ HÀNG CỦA QUÍ VỊ ĐANG TRỐNG, CHƯA THÊM SẢN PHẨM";
            lbKQ.Text = ""; //Xóa trống phần tính tiền
            ButtonOrder.Enabled = false;//KHÔNG "Đặt hàng" được
            ButtonOrder.ToolTip = "Giỏ hàng rỗng nên không có gì để đặt hàng; Mời quí vị Chọn sản phẩm!";
        }
        else//Giỏ hàng đã có
        {
            lbTittle.Text = " GIỎ HÀNG HIỆN TẠI CỦA QUÍ VỊ NHƯ SAU:";
         //B1: LẤY GIỎ HÀNG TỪ Session XUỐNG
            tbl = Session["giohang"] as DataTable;
         //B2: GÁN GIỎ HÀNG VÀO GridView :  QUANG TRỌNG NHẤT
            GridView1.DataSource = tbl;
         //B3: TẢI DỮ LIỆU TỪ tbl LÊN GridView
            GridView1.DataBind();
            //B4: TÍNH TOÁN: SỐ LƯỢNG MÓN + TỔNG TIỀN
            lbKQ.Text = "GIỎ HÀNG HIỆN CÓ : " + tbl.Compute("Count(msmh)", "").ToString() + " SẢN PHẨM, TỔNG TIỀN = " + tbl.Compute("Sum(tien)", "").ToString() + " Đồng";
            ButtonOrder.Enabled = true;//"Đặt hàng" được
            ButtonOrder.ToolTip = "";
        }
    }
    //GỌI FORM ĐẶT HÀNG = ORDER
    protected void ButtonOrder_Click(object sender, EventArgs e)
    {
        Response.Redirect("~\\Order.aspx");
    }
}