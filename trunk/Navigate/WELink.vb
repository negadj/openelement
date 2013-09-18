﻿Imports System.ComponentModel
Imports System.Drawing.Design

Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Navigate

    <Serializable> _
    Public Class WELink
        Inherits ElementBaseTextIcon

        #Region "Fields"

        Private _PageLink As Link
        Private _Text As LocalizableHtml

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WELink", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N003"), _
        LocalizableDescAtt("_D003"), _
        Editor(GetType(UITypeLinkPage), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property PageLink() As Link
            Get
                If _PageLink Is Nothing Then
                    _PageLink = New Link()
                End If
                Return _PageLink
            End Get
            Set(ByVal value As Link)
                _PageLink = value
            End Set
        End Property

        <Browsable(False), _
        TypeConverter(GetType(TConvLocalizableString))> _
        Public Property Text() As LocalizableHtml
            Get
                If _Text Is Nothing Then
                    _Text = New LocalizableHtml(LocalizablePropertyDefaultValue._0005) '"Nouveau lien")
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

            Dim lsID As String = "WELink." & ID & ".Text"
            accListLS(lsID) = _Text

            If Not String.IsNullOrEmpty(Me.Name) Then
                accListInfo(lsID) = "Element name: " & Me.Name & " (Link)"
            End If

            Return True
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0035
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WELink
            info.ToolBoxDescription = LocalizableOpen._0036
            info.AutoOpenProperty = "PageLink"
            info.SortPropertyList.Add(New SortProperty("PageLink", "link.png", LocalizableOpen._0010))
            Return info
        End Function

        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "BaseDiv", "DivContent"
                    configStylesZones.IsLink = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Link", LocalizableFormAndConverter._0176, LocalizableFormAndConverter._0176))

            MyBase.TextIconZoneName = "Link"

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            Dim linkOnClick As Link = Me.PageLink
            If IsDynamic Then linkOnClick = Nothing ' disable onclick handler for container div if element has dynamic structure behind

            MyBase.RenderBeginTag(writer, linkOnClick)

            Dim linkAttr As New Dictionary(Of String, String)
            linkAttr.Add("class", MyBase.GetStyleZoneClass("Link"))
            writer.WriteHtmlBlockLinkEdit(Me, "Text", False, Me.PageLink, True, , , linkAttr)

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

