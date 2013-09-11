Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel

Namespace Elements.Navigate


    <Serializable()> _
    Public Class WELinkButton
        Inherits ElementBaseTextIcon

        Private _Text As DataType.LocalizableHtml
        Private _PageLink As LinksManager.Link
 
#Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N003"), _
        Ressource.localizable.LocalizableDescAtt("_D003"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkPage), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property PageLink() As LinksManager.Link
            Get
                If _PageLink Is Nothing Then
                    _PageLink = New LinksManager.Link()
                End If
                Return _PageLink
            End Get
            Set(ByVal value As LinksManager.Link)
                _PageLink = value
            End Set
        End Property


        <Browsable(False)> _
        Public Property Text() As DataType.LocalizableHtml
            Get
                If _Text Is Nothing Then
                    _Text = New DataType.LocalizableHtml(My.Resources.text.LocalizablePropertyDefaultValue._0005)
                End If
                Return _Text
            End Get
            Set(ByVal value As DataType.LocalizableHtml)
                _Text = value
            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WELinkButton", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0031
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WELinkButton
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0032
            info.AutoOpenProperty = "PageLink"
            info.SortPropertyList.Add(New SortProperty("PageLink", "link.png", My.Resources.text.LocalizableOpen._0010))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)

            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Text", My.Resources.text.LocalizableFormAndConverter._0177, My.Resources.text.LocalizableFormAndConverter._0177))
            
            MyBase.TextIconZoneName = "Text"

            MyBase.OnOpen(ConfigStylesZones)
        End Sub

        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As openElement.WebElement.StylesManager.ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "BaseDiv", "DivContent"
                    configStylesZones.IsLink = True
                Case "Text"
                    configStylesZones.GlobalEvent = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer, PageLink)

            Dim linkAttr As New Dictionary(Of String, String)
            linkAttr.Add("class", MyBase.GetStyleZoneClass("Text"))
            writer.WriteHtmlBlockLinkEdit(Me, "Text", False, Me.PageLink, False, , , linkAttr)

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

            Dim lsID As String = "WELinkButton." & ID & ".Text"
            accListLS(lsID) = _Text

            If Not String.IsNullOrEmpty(Me.Name) Then
                accListInfo(lsID) = "Element name: " & Me.Name & " (Link button)"
            End If

            Return True
        End Function

#End Region



    End Class

End Namespace



