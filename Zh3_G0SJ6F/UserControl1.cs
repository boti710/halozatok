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
    public partial class UserControl1 : UserControl
    {
        TextbookSupportContext context = new TextbookSupportContext();
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            Dikaszuro();
            Konyvszuro();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Dikaszuro();

        }

        private void Dikaszuro()
        {
            listBox1.DataSource =
                                    (
                                        from s in context.Students
                                        where s.Name.Contains(textBox1.Text)
                                        select s
                                    ).ToList();

            listBox1.DisplayMember = "Neptun";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Konyvszuro();
        }

        private void Konyvszuro()
        {
            listBox2.DataSource =
                        (
                            from t in context.Textbooks
                            where t.Title.Contains(textBox2.Text)
                            select t
                        ).ToList();
            listBox2.DisplayMember = "Title";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rendeltkonvyek();
        }

        private void Rendeltkonvyek()
        {
            Student student = (Student)listBox1.SelectedItem;
            var a = from x in context.Orders
                    where x.StudentFk == student.StudentId
                    select new DetailedOrderItem
                    {
                        OrderSk = x.OrderSk,
                        StudentFk = x.StudentFk,
                        Title = x.TextbookFkNavigation.Title
                    };
            listBox3.DataSource = a.ToList();
            listBox3.DisplayMember = "Title";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Hozzáadja a tankönyvet?", "Tankönyv hozzáadás", MessageBoxButtons.YesNo);

            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                Student student = (Student)listBox1.SelectedItem;
                Textbook textbook = (Textbook)listBox2.SelectedItem;
                Order o = new Order();

                o.StudentFk = student.StudentId;
                o.TextbookFk = textbook.TextbookId;
                context.Orders.Local.Add(o);

                try

                {
                    context.SaveChanges();
                }

                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message);
                }

                Rendeltkonvyek();


            }
            
        }


      

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Biztosan törli a tankönyvet?", "Törlés", MessageBoxButtons.YesNo);

            if (res == System.Windows.Forms.DialogResult.Yes)
            {

                var valasztottrendeles = (DetailedOrderItem)listBox3.SelectedItem;
                var b = from x in context.Orders

                        where x.OrderSk == valasztottrendeles.OrderSk
                        select x;

                context.Orders.Remove(b.FirstOrDefault());

                try

                {
                    context.SaveChanges();
                }

                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message);
                }

                Rendeltkonvyek();
            }
        }
    }
    public class DetailedOrderItem

    {
        public int OrderSk { get; set; }
        public int? StudentFk { get; set; }
        public string Title { get; set; }

    }
}
