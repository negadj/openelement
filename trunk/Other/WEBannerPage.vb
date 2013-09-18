Imports System.ComponentModel
Imports System.Drawing.Design

Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager.CssItems

Imports WebElement.Elements.Other.Editors.Converter
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Other

    <Serializable> _
    Public Class WEBannerPage
        Inherits ElementBase

        #Region "Fields"

        Private _HeaderPosition As EnuHeaderPosition
        Private _Height As CssUnit
        Private _PageLink As Link

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.HiddenEdit, "WEBannerPage", page, parentID, templateName)
        End Sub

        #End Region 'Constructors

        #Region "Enumerations"

        Public Enum EnuHeaderPosition As Short
            Top = 0
            Bottom = 1
        End Enum

        #End Region 'Enumerations

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N102"), _
        LocalizableDescAtt("_D102"), _
        TypeConverter(GetType(TConvEnuHeaderPosition)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property HeaderPosition() As EnuHeaderPosition
            Get
                Return _HeaderPosition
            End Get
            Set(ByVal value As EnuHeaderPosition)
                _HeaderPosition = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N098"), _
        LocalizableDescAtt("_D098"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Height() As CssUnit
            Get
                If _Height Is Nothing Then
                    _Height = New CssUnit
                    _Height.SetCss("100px")
                End If
                Return _Height
            End Get
            Set(ByVal value As CssUnit)
                _Height = value
            End Set
        End Property

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property HeightJs() As String
            Get
                Return Me.Height.ToCss
            End Get
        End Property

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property LinkType() As Integer
            Get
                Return PageLink.GetLinkType(Me.Page.Culture)
            End Get
        End Property

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
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property PageLinkJs() As String
            Get
                Return MyBase.GetLink(PageLink)
            End Get
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0135
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupOther"
            info.ToolBoxIco = My.Resources.WELink
            info.ToolBoxDescription = LocalizableOpen._0136
            info.SortPropertyList.Add(New SortProperty("PageLink", "link.png", LocalizableOpen._0010))
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEBannerPage.js", "WEFiles/Client/WEBannerPage.js")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnOpen()
            MyBase.OnOpen()
        End Sub

        #End Region 'Methods

    End Class

End Namespace

