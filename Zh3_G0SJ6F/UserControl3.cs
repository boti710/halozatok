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
    public partial class UserControl3 : UserControl
    {
        TextbookSupportContext context = new TextbookSupportContext();
        public UserControl3()
        {
            InitializeComponent();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            Nevszuro();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Nevszuro();
        }

        private void Nevszuro()
        {
            listBox1.DataSource =
                                 (

                             from s in context.Students
                             where s.Name.StartsWith(textBox1.Text)
                             select s
                                    ).ToList();

            listBox1.DisplayMember = "Name";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Student diak = (Student)listBox1.SelectedItem;

            var a = from x in context.Students
                    where x.StudentId == diak.StudentId
                    select new
                    {
                        StudentId = diak.StudentId,
                        Neptun = diak.Neptun
                    };

            studentBindingSource.DataSource = a.ToList();
        }
    }

}
