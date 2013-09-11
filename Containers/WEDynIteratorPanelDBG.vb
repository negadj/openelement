Imports openElement.WebElement
Imports openElement.WebElement.StylesManager
Imports System.Drawing
Imports openElement.WebElement.Elements

Namespace Elements.Dynamic


    <Serializable()> _
    Public Class WEDynIteratorPanelDBG ' ! when change class, change name in constructor too
        Inherits Elements.Standard.WEPanel

#Region "Empty overrides (almost no real code, redirection to base method)"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(page, parentID, templateName, "WEDynIteratorPanelDBG")
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = "DBG Iterator Simple"
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Repetitions", My.Resources.text.LocalizableOpen._0399, My.Resources.text.LocalizableOpen._0401))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("RepetitionsEven", My.Resources.text.LocalizableOpen._0400, My.Resources.text.LocalizableOpen._0402))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)
            MyBase.Render(writer)
        End Sub

#End Region

#Region "Dyn init"

        Protected Overrides Sub DynInitialize()
            MyBase.DynInitialize()
            TestInitDynElementLoginTest()
            TestInitDynElementIterator()
        End Sub

#End Region

#Region "Render Dynamic"

        Protected Overrides Sub RenderPanelContent(ByVal writer As Common.HtmlWriter)
            If Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then
                MyBase.RenderPanelContent(writer) ' render children
                Exit Sub
            End If

            ' DD iterate child elements

            ' Analyse dimensions //////////////////////////////

            ' find container dimensions in pixels, to generate relative div of needed size that repeats for every row
            Dim bstyle As Styles = StylesSkin.BaseDiv.BaseStyles
            Dim panelWidth As Integer = bstyle.Width.GetNumber()
            Dim panelHeight As Integer = bstyle.Height.GetNumber()

            ' find dimentions of all the child elements tohether (as if it was a group selection rectangle somewhere in Photoshop):
            Dim left, top, right, bottom As Integer
            Dim dims As Point = DetectChildElementsDims(left, top, right, bottom)
            Dim iterationDivWidth = right - left : If left > 0 Then iterationDivWidth += left * 2 ' cosider left of the leftmost element as half the padding between iterated elements
            Dim iterationDivHeight = bottom - top : If top > 0 Then iterationDivHeight += top * 2 ' cosider top of the highest element as half the padding between iterated elements

            If iterationDivHeight <= 0 Then ' failed to find child elements
                MyBase.RenderPanelContent(writer) ' base static render
                Exit Sub
            End If
            Dim styleWidth = "100%" : If iterationDivWidth > 0 Then styleWidth = iterationDivWidth.ToString() & "px"
            Dim styleHeight As String = iterationDivHeight.ToString() & "px"

            ' Render ////////////////////////////////////////

            ' (optional - if no need to update with AJAX, no need to explicitly specify tag with iteration zone)
            ' start tag with jQuery-updatable iteration zone:
            DTWriteBeginTagWithIterators("div", writer)
            ' end tag declaration => start inner HTML => start of iteration zone:
            DTTagEndDeclaration()
            ' (end of optional code)


            ' Start the iterator itself (repeats everything inside according to data rows); 
            ' no parameter means that data to iterate through are detected automatically:
            DTIteratorBegin()

            ' relative div of needed size that repeats for every row
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", String.Concat(MyBase.GetStyleZoneClass("Repetitions"), DTIteratorWrapEvenOnlyCode(" " & MyBase.GetStyleZoneClass("RepetitionsEven"))))

            writer.WriteAttribute("style", _
                                  String.Format("display:inline-block;position: relative;width:{0};height:{1};margin:0 !important;", styleWidth, styleHeight))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            MyBase.RenderPanelContent(writer) ' render children

            writer.WriteEndTag("div") ' end 

            ' End iterator
            DTIteratorEnd()
            ' Note: DTIteratorBegin() .... DTIteratorEnd() is the minimum necessary iterator code.
            ' Sometimes it's all that's needed, like when no need for AJAX updates; 
            ' in such cases, no need for DTWriteBeginTagWithIterators()


            DTWriteEndTag("div") ' end tag with iteration zone (if it DTWriteBeginTagWithIterators() was used above):

        End Sub


#End Region



    End Class

End Namespace
