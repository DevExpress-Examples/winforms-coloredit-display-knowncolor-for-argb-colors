using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;

namespace WindowsApplication78
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ParentID", typeof(int));
            dt.Columns.Add("COLOR", typeof(int));
            dt.Rows.Add(new object[] { 0, -1, 0 });
            dt.Rows.Add(new object[] { 1, 0, Color.Red.ToArgb() });
            dt.Rows.Add(new object[] { 2, -1, Color.Green.ToArgb() });
            dt.Rows.Add(new object[] { 3, 0, Color.Blue.ToArgb() });
            dt.Rows.Add(new object[] { 4, 1, Color.FromArgb(255, 255, 0, 255).ToArgb() });
            dt.Rows.Add(new object[] { 5, 2, Color.Transparent.ToArgb() });

            RepositoryItemColorEdit ri = new CustomEditors.RepositoryItemMyColorEdit();
            ri.StoreColorAsInteger = true;
            treeList1.RepositoryItems.Add(ri);
            treeListColumn1.ColumnEdit = ri;
            treeList1.DataSource = dt;
        }

    }


}