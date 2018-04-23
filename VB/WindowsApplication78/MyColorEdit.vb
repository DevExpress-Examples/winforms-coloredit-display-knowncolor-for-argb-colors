Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Popup
Imports System.Drawing
Imports System.Collections

Namespace CustomEditors
	<UserRepositoryItem("Register")> _
	Public Class RepositoryItemMyColorEdit
		Inherits RepositoryItemColorEdit
		Shared Sub New()
			Register()
		End Sub
		Public Sub New()
		End Sub

		Friend Const EditorName As String = "MyColorEdit"

		Public Shared Sub Register()
			EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(MyColorEdit), GetType(RepositoryItemMyColorEdit), GetType(DevExpress.XtraEditors.ViewInfo.ColorEditViewInfo), New DevExpress.XtraEditors.Drawing.ColorEditPainter(), True, CType(Nothing, Image)))
		End Sub
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return EditorName
			End Get
		End Property

		Protected Overrides Function GetColorDisplayText(ByVal editValue As Color) As String
			Dim color As Object = editValue
			ColorHelper.TryConvertToKnownColor(color)
			Return MyBase.GetColorDisplayText(CType(color, Color))
		End Function
	End Class

	Friend Class ColorHelper
		Shared Sub New()
			knownColorsHash = InitKnownColorsHash()
		End Sub
		Private Sub New()
		End Sub

		Private Shared knownColorsHash As Hashtable

		Private Shared Function InitKnownColorsHash() As Hashtable
			Dim knownColors As System.Array = System.Enum.GetValues(GetType(KnownColor))
			Dim hashtable As New Hashtable(knownColors.Length)
			For Each knownColorObject As KnownColor In knownColors
				Dim color As Color = Color.FromKnownColor(knownColorObject)
				Dim argbValue As Integer = color.ToArgb()
				If color.IsSystemColor AndAlso hashtable.ContainsKey(argbValue) Then
					Continue For
				End If
				hashtable(argbValue) = knownColorObject
			Next knownColorObject
			Return hashtable
		End Function

		Public Shared Function TryConvertToKnownColor(ByRef color As Object) As Boolean
			Dim knownColor As KnownColor = GetKnownColor(color)
			If knownColor <> 0 Then
				color = System.Drawing.Color.FromKnownColor(knownColor)
				Return True
			End If
			Return False
		End Function

		Public Shared Function GetKnownColor(ByVal color As Color) As KnownColor
			Dim knownColor As KnownColor = color.ToKnownColor()
			If knownColor = 0 Then
				knownColor = GetKnownColor(color.ToArgb())
			End If
			Return knownColor
		End Function
		Public Shared Function GetKnownColor(ByVal argb As Integer) As KnownColor
			Dim result As Object = knownColorsHash(argb)
			If result Is Nothing Then
				Return 0
			End If
			Return CType(result, KnownColor)
		End Function

		Public Shared Function GetKnownColor(ByVal color As Object) As KnownColor
			If TypeOf color Is KnownColor Then
				Return CType(color, KnownColor)
			End If
			If TypeOf color Is Color Then
				Return GetKnownColor(CType(color, Color))
			End If
			If TypeOf color Is Integer Then
				Return GetKnownColor(CInt(Fix(color)))
			End If
			Return 0
		End Function
	End Class

	Public Class MyColorEdit
		Inherits ColorEdit
		Shared Sub New()
			RepositoryItemMyColorEdit.Register()
		End Sub
		Public Sub New()
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemMyColorEdit.EditorName
			End Get
		End Property
	End Class
End Namespace

