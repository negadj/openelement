Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Control.CtlEditListOf


Namespace Elements.Containers

    <Serializable()> _
    Public Class WEAccordion
        Inherits ElementBase

#Region "Private variable"

        ''' <summary>
        ''' list of accordion panel
        ''' </summary>
        ''' <remarks></remarks>
        <Common.Attributes.ContainsLinks()> _
        Private _AccordionGroups As List(Of WEAccordionGroup)
        ''' <summary>
        ''' Opening index at the loading page
        ''' </summary>
        ''' <remarks></remarks>
        Private _OpenGroupIndex As Integer = 0
        ''' <summary>
        ''' slow effect
        ''' </summary>
        ''' <remarks></remarks>
        Private _Easing As DataType.Enum.EnumEasingEffect
        <NonSerialized()> _
        Private _EasingJS As String

#End Region

#Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N001"), _
        Ressource.localizable.LocalizableDescAtt("_D011"), _
        Editor(GetType(UITypeEditListOf), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property AccordionGroups() As List(Of WEAccordionGroup)
            Get
                If _AccordionGroups Is Nothing Then _AccordionGroups = New List(Of WEAccordionGroup)
                Return _AccordionGroups
            End Get
            Set(ByVal value As List(Of WEAccordionGroup))
                Call UpdateTemplates(_AccordionGroups, value)
                _AccordionGroups = value
            End Set
        End Property

        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public Property OpenGroupIndex() As Integer
            Get
                Return _OpenGroupIndex
            End Get
            Set(ByVal value As Integer)
                _OpenGroupIndex = value
            End Set
        End Property

        ''' <summary>
        ''' visual effect
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N232"), _
        Ressource.localizable.LocalizableDescAtt("_D232"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.Enum.TConvEnumEasingEffect)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Easing() As DataType.Enum.EnumEasingEffect
            Get
                Return _Easing
            End Get
            Set(ByVal value As DataType.Enum.EnumEasingEffect)
                _Easing = value
            End Set
        End Property
        ''' <summary>
        ''' Export of the effect at js file
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingJs() As String
            Get
                Return _Easing.ToString
            End Get
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEAccordion", page, parentID, templateName)

            Dim group1 As New WEAccordionGroup(NewTemplate)
            group1.Title.SetValue(My.Resources.text.LocalizableFormAndConverter._0156 & " 1")
            Dim group2 As New WEAccordionGroup(NewTemplate)
            group2.Title.SetValue(My.Resources.text.LocalizableFormAndConverter._0156 & " 2")

            Me.AccordionGroups.Add(group1)
            Me.AccordionGroups.Add(group2)

        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0157
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupContainers"
            info.ToolBoxIco = My.Resources.WEPanel
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0158
            info.SortPropertyList.Add(New SortProperty("AccordionGroups", "tools.png", My.Resources.text.LocalizableOpen._0030))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionHeader", My.Resources.text.LocalizableOpen._0147, My.Resources.text.LocalizableOpen._0148))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionHeaderContent", My.Resources.text.LocalizableOpen._0314, My.Resources.text.LocalizableOpen._0321))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionHeaderLeft", My.Resources.text.LocalizableOpen._0315, My.Resources.text.LocalizableOpen._0322))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionHeaderRight", My.Resources.text.LocalizableOpen._0316, My.Resources.text.LocalizableOpen._0323))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionHeaderActive", My.Resources.text.LocalizableOpen._0317, My.Resources.text.LocalizableOpen._0324))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionHeaderContentActive", My.Resources.text.LocalizableOpen._0318, My.Resources.text.LocalizableOpen._0325))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionHeaderLeftActive", My.Resources.text.LocalizableOpen._0319, My.Resources.text.LocalizableOpen._0326))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionHeaderRightActive", My.Resources.text.LocalizableOpen._0320, My.Resources.text.LocalizableOpen._0327))

            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionIcon", My.Resources.text.LocalizableOpen._0149, My.Resources.text.LocalizableOpen._0150))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionTitle", My.Resources.text.LocalizableOpen._0151, My.Resources.text.LocalizableOpen._0152))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionAltTitle", My.Resources.text.LocalizableOpen._0153, My.Resources.text.LocalizableOpen._0154))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("WEAccordionContent", My.Resources.text.LocalizableOpen._0155, My.Resources.text.LocalizableOpen._0156))

            MyBase.OnOpen(configStylesZones)

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQueryUICore)
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQueryUIAccordion)
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQueryEasing)
            MyBase.AddExternalScripts(Common.EnuScriptType.Css, "ElementsLibrary\Common\Css\WEAccordion.css", "WEFiles/Css/WEAccordion.css")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEAccordion.js", "WEFiles/Client/WEAccordion.js")
            MyBase.OnInitExternalFiles()
        End Sub

#End Region

        Protected Overrides Sub OnDataFromJs(ByVal data As String)
            If data Is Nothing Then Me.OpenGroupIndex = -1 : Exit Sub
            Dim index As Integer = 0
            For Each group As WEAccordionGroup In Me.AccordionGroups
                If group.ID.Equals(data) Then
                    Me.OpenGroupIndex = index
                    Exit Sub
                End If
                index += 1
            Next
            Me.OpenGroupIndex = -1
        End Sub

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As AddButton, ByVal selectedNodeTag As NodeTag) As List(Of Object)
            Dim newObs As New List(Of Object)
            newObs.Add(New WEAccordionGroup(NewTemplate))
            Return newObs
        End Function

        ''' <summary>
        ''' Find a unique name for the new panel to accordion
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function NewTemplate() As String
            Dim templateName As String = System.Guid.NewGuid.ToString().Substring(0, 8)
            MyBase.Templates.SetTemplate(templateName, StylesManager.CssItems.CssEnum.PositionMode.absolute)
            Return templateName
        End Function


#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            Dim index As Integer = 0
            For Each group As WEAccordionGroup In Me.AccordionGroups

                'WEAccordionHeader
                writer.WriteBeginTag("div")
                writer.WriteAttribute("id", group.ID)
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionHeader"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                'WEAccordionHeaderLeft
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionHeaderLeft"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("span")

                'WEAccordionHeaderContent
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionHeaderContent"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)


                writer.WriteBeginTag("a")
                writer.WriteAttribute("href", "#")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)


                writer.WriteLine()



                If group.IconOff.IsEmpty() Or group.IconOn.IsEmpty() Then
                Else
                    'WEAccordionIcon
                    writer.WriteBeginTag("span")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionIcon"))

                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                    writer.WriteBeginTag("img")
                    If index.Equals(Me.OpenGroupIndex) Then
                        writer.WriteAttribute("src", MyBase.GetLink(group.IconOn))
                    Else
                        writer.WriteAttribute("src", MyBase.GetLink(group.IconOff))
                    End If
                    writer.WriteAttribute("style", "border:0px none")
                    writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

                    writer.WriteEndTag("span")
                    writer.WriteLine()
                End If

                'WEAccordionTitle
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionTitle"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                writer.Write(group.Title.GetValue(Me.Page.Culture))
                writer.WriteEndTag("span")
                writer.WriteEndTag("a")
                writer.WriteLine()

                'WEAccordionAltTitle
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionAltTitle"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteBeginTag("a")
                writer.WriteAttribute("href", "#")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.Write(group.AlternateTitle.GetValue(Me.Page.Culture))
                writer.WriteEndTag("a")
                writer.WriteEndTag("span")
                writer.WriteLine()

                writer.WriteEndTag("span") 'WEAccordionHeaderContent's end
                writer.WriteLine()


                'WEAccordionHeaderRight
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionHeaderRight"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("span")
                writer.WriteLine()

                writer.WriteEndTag("div") 'WEAccordionHeader end

                'WEAccordionContent
                writer.WriteBeginTag("div")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEAccordionContent"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                writer.WriteBeginTag("div")
                writer.WriteAttribute("class", MyBase.GetTemplateClass(group.ID))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteLine()


                MyBase.RenderTemplate(writer, group.ID)


                writer.WriteLine()
                writer.WriteEndTag("div")

                writer.WriteLine()
                writer.WriteEndTag("div")

                index = index + 1
            Next


            MyBase.RenderEndTag(writer)

        End Sub

#End Region

        ''' <summary>
        ''' Check the panel name (must be unique)
        ''' </summary>
        ''' <param name="groups"></param>
        ''' <param name="templateName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function TemplateNameExiste(ByVal groups As List(Of WEAccordionGroup), ByVal templateName As String) As Boolean
            For Each group As WEAccordionGroup In groups
                If group.ID.Equals(templateName) Then Return True
            Next
        End Function

        Private Sub UpdateTemplates(ByVal oldGroups As List(Of WEAccordionGroup), ByVal newGroups As List(Of WEAccordionGroup))
            For Each oldGroup As WEAccordionGroup In oldGroups
                If Not TemplateNameExiste(newGroups, oldGroup.ID) Then
                    MyBase.Templates.Templates.Remove(oldGroup.ID)
                End If
            Next
        End Sub


#Region "DD Translation of LocalizableStrings"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
                                        ByVal accListLS As Dictionary(Of String, DataType.LocalizableString), _
                                        ByVal accListInfo As Dictionary(Of String, String), _
                                        Optional ByVal onlyNonEmpty As Boolean = True) As Boolean

            Dim r As Boolean = False

            If _AccordionGroups Is Nothing OrElse _AccordionGroups.Count < 1 Then Return r

            Dim cntr As Integer = 0
            For Each item In _AccordionGroups
                cntr += 1
                r = r Or AddLSForTranslationSystem(item.Title, "Group" & cntr.ToString & ".Title", "WEContainers", "Accordion Container", accListLS, accListInfo, onlyNonEmpty)
                r = r Or AddLSForTranslationSystem(item.AlternateTitle, "Group" & cntr.ToString & ".AltTitle", "WEContainers", "Accordion Container", accListLS, accListInfo, onlyNonEmpty)
                r = r Or AddLSForTranslationSystem(item.Description, "Group" & cntr.ToString & ".Description", "WEContainers", "Accordion Container", accListLS, accListInfo, onlyNonEmpty)
            Next
            Return r
        End Function

#End Region

    End Class


End Namespace