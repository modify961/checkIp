using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = MongoHelper.obtainAll().Count().ToString();
        Label2.Text = AbandonIP.obtainAll().Count().ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        List<Agenter> list = MongoHelper.obtainAll();
        if (list != null)
        {
            rpt.DataSource = list;
            rpt.DataBind();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //MongoHelper.obtainByIp("118.114.77.47");
        //MongoHelper.insert(new Agenter("124.34.34.234,90,https"));
        //MongoHelper.delete();
        //MongoHelper.update(new Agenter()
        //{
        //    ip = "124.34.34.234"
        //});
        //MongoHelper.delete();
        //MongoHelper.connection();
        //RabbitMQHelper.MQReceive mqReceive = new RabbitMQHelper.MQReceive();
        //mqReceive.Receive();
    }
}