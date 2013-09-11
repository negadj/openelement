Imports openElement.WebElement
Imports System.ComponentModel
Imports Newtonsoft.Json


Namespace Elements.Containers

    
    <Serializable()> _
    Public Class WEAccordionGroup

        ''' <summary>
        ''' Panel's title displayed on top
        ''' </summary>
        ''' <remarks></remarks>
        Private _Title As DataType.LocalizableString
        ''' <summary>
        ''' Secondary title displayed on top
        ''' </summary>
        ''' <remarks></remarks>
        Private _AlternateTitle As DataType.LocalizableString
        ''' <summary>
        ''' closed panel icon
        ''' </summary>
        ''' <remarks></remarks>
        Private _IconOff As LinksManager.Link
        ''' <summary>
        ''' opened panel icon
        ''' </summary>
        ''' <remarks></remarks>
        Private _IconOn As LinksManager.Link
      
        Private _Description As DataType.LocalizableString

        ''' <summary>
        ''' panel unique id
        ''' </summary>
        ''' <remarks></remarks>
        Private _ID As String


        Public Sub New(ByVal ID As String)
            _ID = ID
        End Sub


        <Browsable(False)> _
        Public Property ID() As String
            Get
                Return _ID
            End Get
            Set(ByVal value As String)
                _ID = value
            End Set
        End Property



        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N105"), _
        Ressource.localizable.LocalizableDescAtt("_D105"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFile), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.ElementWithCss), _
        Common.Attributes.ConfigBiblio(True, False, False, False, False), _
        Common.Attributes.EditListOf.ShowColumn(Common.Attributes.EditListOf.ShowColumn.ENURepositoryType.RepositoryItemPictureEdit, 30, 30)> _
        Public Property IconOn() As LinksManager.Link
            Get
                If _IconOn Is Nothing Then _IconOn = New LinksManager.Link
                Return _IconOn
            End Get
            Set(ByVal value As LinksManager.Link)
                _IconOn = value
            End Set
        End Property


        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N104"), _
        Ressource.localizable.LocalizableDescAtt("_D104"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFile), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.ElementWithCss), _
        Common.Attributes.ConfigBiblio(True, False, False, False, False)> _
        Public Property IconOff() As LinksManager.Link
            Get
                If _IconOff Is Nothing Then _IconOff = New LinksManager.Link
                Return _IconOff
            End Get
            Set(ByVal value As LinksManager.Link)
                _IconOff = value
            End Set
        End Property


        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N103"), _
        Ressource.localizable.LocalizableDescAtt("_D103"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        Common.Attributes.EditListOf.ShowColumn(), _
        JsonIgnore()> _
        Public Property Title() As DataType.LocalizableString
            Get
                If _Title Is Nothing Then _Title = New DataType.LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0019) 'Titre du groupe
                Return _Title
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _Title = value
            End Set
        End Property


        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N107"), _
        Ressource.localizable.LocalizableDescAtt("_D107"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        JsonIgnore()> _
        Public Property Description() As DataType.LocalizableString
            Get
                If _Description Is Nothing Then _Description = New DataType.LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0020) '"Description du groupe"
                Return _Description
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _Description = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N108"), _
        Ressource.localizable.LocalizableDescAtt("_D108"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        JsonIgnore()> _
        Public Property AlternateTitle() As DataType.LocalizableString
            Get
                If _AlternateTitle Is Nothing Then _AlternateTitle = New DataType.LocalizableString("")
                Return _AlternateTitle
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _AlternateTitle = value
            End Set
        End Property


    End Class

End Namespace
