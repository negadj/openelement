Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel

Namespace Elements.Other


    <Serializable()> _
    Public Class WEBannerPage
        Inherits ElementBase

        Public Enum EnuHeaderPosition As Short
            Top = 0
            Bottom = 1
        End Enum

#Region "Properties"

        Private _PageLink As LinksManager.Link
        Private _Height As StylesManager.CssItems.CssUnit
        Private _HeaderPosition As EnuHeaderPosition

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N102"), _
        Ressource.localizable.LocalizableDescAtt("_D102"), _
        TypeConverter(GetType(Editors.Converter.TConvEnuHeaderPosition)), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property HeaderPosition() As EnuHeaderPosition
            Get
                Return _HeaderPosition
            End Get
            Set(ByVal value As EnuHeaderPosition)
                _HeaderPosition = value
            End Set
        End Property

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

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N098"), _
        Ressource.localizable.LocalizableDescAtt("_D098"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Height() As StylesManager.CssItems.CssUnit
            Get
                If _Height Is Nothing Then
                    _Height = New StylesManager.CssItems.CssUnit
                    _Height.SetCss("100px")
                End If
                Return _Height
            End Get
            Set(ByVal value As StylesManager.CssItems.CssUnit)
                _Height = value
            End Set
        End Property


        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property LinkType() As Integer
            Get
                Return PageLink.GetLinkType(Me.Page.Culture)
            End Get
        End Property

        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property PageLinkJs() As String
            Get
                Return MyBase.GetLink(PageLink)
            End Get
        End Property

        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property HeightJs() As String
            Get
                Return Me.Height.ToCss
            End Get
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.HiddenEdit, "WEBannerPage", page, parentID, templateName)
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0135
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupOther"
            info.ToolBoxIco = My.Resources.WELink
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0136
            info.SortPropertyList.Add(New SortProperty("PageLink", "link.png", My.Resources.text.LocalizableOpen._0010))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            MyBase.OnOpen()

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEBannerPage.js", "WEFiles/Client/WEBannerPage.js")
            MyBase.OnInitExternalFiles()
        End Sub

#End Region

    End Class

End Namespace



