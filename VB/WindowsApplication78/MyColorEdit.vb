Imports System
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports System.Drawing
Imports System.Collections

Namespace CustomEditors

    <UserRepositoryItem("Register")>
    Public Class RepositoryItemMyColorEdit
        Inherits RepositoryItemColorEdit

        Shared Sub New()
            Call Register()
        End Sub

        Public Sub New()
        End Sub

        Friend Const EditorName As String = "MyColorEdit"

        Public Shared Sub Register()
            Call EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(MyColorEdit), GetType(RepositoryItemMyColorEdit), GetType(ViewInfo.ColorEditViewInfo), New DevExpress.XtraEditors.Drawing.ColorEditPainter(), True, CType(Nothing, System.Drawing.Image)))
        End Sub

        Public Overrides ReadOnly Property EditorTypeName As String
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
            Dim knownColors As Array = [Enum].GetValues(GetType(KnownColor))
            Dim hashtable As Hashtable = New Hashtable(knownColors.Length)
            For Each knownColorObject As KnownColor In knownColors
                Dim color As Color = Color.FromKnownColor(knownColorObject)
                Dim argbValue As Integer = color.ToArgb()
                If color.IsSystemColor AndAlso hashtable.ContainsKey(argbValue) Then Continue For
                hashtable(argbValue) = knownColorObject
            Next

            Return hashtable
        End Function

        Public Shared Function TryConvertToKnownColor(ByRef color As Object) As Boolean
            Dim knownColor As KnownColor = GetKnownColor(color)
            If knownColor <> 0 Then
                color = Drawing.Color.FromKnownColor(knownColor)
                Return True
            End If

            Return False
        End Function

        Public Shared Function GetKnownColor(ByVal color As Color) As KnownColor
            Dim knownColor As KnownColor = color.ToKnownColor()
            If knownColor = 0 Then knownColor = GetKnownColor(color.ToArgb())
            Return knownColor
        End Function

        Public Shared Function GetKnownColor(ByVal argb As Integer) As KnownColor
            Dim result As Object = knownColorsHash(argb)
            If result Is Nothing Then Return 0
            Return CType(result, KnownColor)
        End Function

        Public Shared Function GetKnownColor(ByVal color As Object) As KnownColor
            If TypeOf color Is KnownColor Then Return CType(color, KnownColor)
            If TypeOf color Is Color Then Return GetKnownColor(CType(color, Color))
            If TypeOf color Is Integer Then Return GetKnownColor(CInt(color))
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

        Public Overrides ReadOnly Property EditorTypeName As String
            Get
                Return RepositoryItemMyColorEdit.EditorName
            End Get
        End Property
    End Class
End Namespace
