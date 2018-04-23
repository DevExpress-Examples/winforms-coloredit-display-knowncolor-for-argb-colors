Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository

Namespace WindowsApplication78
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			Dim dt As New DataTable()
			dt.Columns.Add("ID", GetType(Integer))
			dt.Columns.Add("ParentID", GetType(Integer))
			dt.Columns.Add("COLOR", GetType(Integer))
			dt.Rows.Add(New Object() { 0, -1, 0 })
			dt.Rows.Add(New Object() { 1, 0, Color.Red.ToArgb() })
			dt.Rows.Add(New Object() { 2, -1, Color.Green.ToArgb() })
			dt.Rows.Add(New Object() { 3, 0, Color.Blue.ToArgb() })
			dt.Rows.Add(New Object() { 4, 1, Color.FromArgb(255, 255, 0, 255).ToArgb() })
			dt.Rows.Add(New Object() { 5, 2, Color.Transparent.ToArgb() })

			Dim ri As RepositoryItemColorEdit = New CustomEditors.RepositoryItemMyColorEdit()
			ri.StoreColorAsInteger = True
			treeList1.RepositoryItems.Add(ri)
			treeListColumn1.ColumnEdit = ri
			treeList1.DataSource = dt
		End Sub

	End Class


End Namespace