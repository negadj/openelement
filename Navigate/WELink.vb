Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel

Namespace Elements.Navigate


    <Serializable()> _
    Public Class WELink
        Inherits ElementBaseTextIcon

#Region "Properties"

        Private _Text As LocalizableHtml
        Private _PageLink As LinksManager.Link

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


        <Browsable(False), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString))> _
        Public Property Text() As LocalizableHtml
            Get
                If _Text Is Nothing Then
                    _Text = New LocalizableHtml(My.Resources.text.LocalizablePropertyDefaultValue._0005) '"Nouveau lien")
                End If
                Return _Text
            End Get
            Set(ByVal value As LocalizableHtml)
                _Text = value
            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WELink", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0035
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WELink
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0036
            info.AutoOpenProperty = "PageLink"
            info.SortPropertyList.Add(New SortProperty("PageLink", "link.png", My.Resources.text.LocalizableOpen._0010))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Link", My.Resources.text.LocalizableFormAndConverter._0176, My.Resources.text.LocalizableFormAndConverter._0176))
 
            MyBase.TextIconZoneName = "Link"

            MyBase.OnOpen(configStylesZones)

        End Sub


        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As StylesManager.ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "BaseDiv", "DivContent"
                    configStylesZones.IsLink = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            Dim linkOnClick As LinksManager.Link = Me.PageLink
            If IsDynamic Then linkOnClick = Nothing ' disable onclick handler for container div if element has dynamic structure behind

            MyBase.RenderBeginTag(writer, linkOnClick)

            Dim linkAttr As New Dictionary(Of String, String)
            linkAttr.Add("class", MyBase.GetStyleZoneClass("Link"))
            writer.WriteHtmlBlockLinkEdit(Me, "Text", False, Me.PageLink, True, , , linkAttr)

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

            Dim lsID As String = "WELink." & ID & ".Text"
            accListLS(lsID) = _Text

            If Not String.IsNullOrEmpty(Me.Name) Then
                accListInfo(lsID) = "Element name: " & Me.Name & " (Link)"
            End If

            Return True
        End Function

#End Region


    End Class

End Namespace



