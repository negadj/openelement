Imports System.ComponentModel

Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Elements

Imports WebElement.My.Resources.text

Namespace Elements.Standard

    ''' <summary>
    ''' Textarea element
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable> _
    Public Class WEText
        Inherits ElementBase

        #Region "Fields"

        Private _Text As LocalizableHtml

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEText", page, parentID, templateName)

            MyBase.TypeResize = EnuTypeResize.Width
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Browsable(False)> _
        Public Property Text() As LocalizableHtml
            Get
                If _Text Is Nothing Then
                    _Text = New LocalizableHtml(LocalizablePropertyDefaultValue._0001)
                End If
                Return _Text
            End Get
            Set(ByVal value As LocalizableHtml)
                _Text = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
            ByVal accListLS As Dictionary(Of String, LocalizableString), _
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

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0001
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupStandard"
            info.ToolBoxIco = My.Resources.WEText
            info.ToolBoxDescription = LocalizableOpen._0002
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            MyBase.OnOpen()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            writer.WriteHtmlBlockEdit(Me, "Text", True)

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

