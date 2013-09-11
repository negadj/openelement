Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel

Namespace Elements.Standard


    <Serializable()> _
    Public Class WEText
        Inherits ElementBase


        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEText", page, parentID, templateName)
            'Mode de redimentionnement par default
            MyBase.TypeResize = EnuTypeResize.Width

        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0001  '"Texte multi-lignes"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupStandard"
            info.ToolBoxIco = My.Resources.WEText
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0002 ' "Ajouter un texte multi-lignes."
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            MyBase.OnOpen()
        End Sub





#Region "Properties"

        Private _Text As DataType.LocalizableHtml

        <Browsable(False)> _
        Public Property Text() As DataType.LocalizableHtml
            Get
                If _Text Is Nothing Then
                    _Text = New DataType.LocalizableHtml(My.Resources.text.LocalizablePropertyDefaultValue._0001) '"Mon texte multi-lignes")
                End If
                Return _Text
            End Get
            Set(ByVal value As DataType.LocalizableHtml)
                _Text = value
            End Set
        End Property

#End Region



#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            writer.WriteHtmlBlockEdit(Me, "Text", True)

            MyBase.RenderEndTag(writer)

        End Sub

#End Region


#Region "DD Translation of LocalizableStrings"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
                                        ByVal accListLS As Dictionary(Of String, DataType.LocalizableString), _
                                        ByVal accListInfo As Dictionary(Of String, String), _
                                        Optional ByVal onlyNonEmpty As Boolean = True) As Boolean
            If accListLS Is Nothing Or accListInfo Is Nothing Then Return False

            If _Text Is Nothing OrElse (onlyNonEmpty AndAlso _Text.IsEmpty) Then Return False

            Dim lsID As String = "WEText." & ID & ".Text"
            accListLS(lsID) = _Text

            If Not String.IsNullOrEmpty(Me.Name) Then
                accListInfo(lsID) = "Element name: " & Me.Name & " (Multi-line text)"
            End If

            Return True
        End Function

#End Region



    End Class

End Namespace



