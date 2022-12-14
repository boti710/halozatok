using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zh3_G0SJ6F.Models;

namespace Zh3_G0SJ6F
{
    public partial class UserControl2 : UserControl
    {
        TextbookSupportContext context = new TextbookSupportContext();
        public UserControl2()
        {
            InitializeComponent();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            CimSzuro();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CimSzuro();

        }

        private void CimSzuro()
        {
            listBox1.DataSource =
                               (
                                  from s in context.Textbooks
                                  where s.Title.StartsWith(textBox1.Text)
                                  select s
                                ).ToList();

            listBox1.DisplayMember = "Title";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Textbook textbook = (Textbook)listBox1.SelectedItem;

            var a = from x in context.Textbooks
                    where x.TextbookId == textbook.TextbookId
                    select new Konyvara

                    {
                        Price = x.Price,
                        StockNumber = x.StockNumber
                    };

            konyvaraBindingSource.DataSource = a.ToList();
        }
    }
    public class Konyvara

    {
        public double? Price { get; set; }
        public string? StockNumber { get; set; }



    }

}
