Imports System.Resources


Namespace Ressource.localizable

    <AttributeUsage(AttributeTargets.All)> _
    Public Class LocalizableDescAtt
        Inherits System.ComponentModel.DescriptionAttribute

        Private _ResourceManager As ResourceManager

        ''' <summary>
        ''' Constructeur utilisé si le ResourceManager est différent de celui par défaut
        ''' </summary>
        ''' <param name="ressName">Nom de la ressource associée au texte</param>
        ''' <param name="ressourceManager">RessouceManager qui contient le texte</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ressName As String, ByVal ressourceManager As ResourceManager)
            MyBase.New(ressName)
            _ResourceManager = ressourceManager
        End Sub
        ''' <summary>
        ''' Constructeur simple (réservé)
        ''' </summary>
        ''' <param name="ressName">Nom de la ressource associée au texte</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ressName As String)
            MyBase.New(ressName)
            _ResourceManager = My.Resources.text.LocalizablePropertyDescription.ResourceManager
        End Sub

        Public Overloads Overrides ReadOnly Property Description() As String
            Get
                Try
                    Dim localizedDescription As String = _ResourceManager.GetString(MyBase.Description)
                    If Not String.IsNullOrEmpty(localizedDescription) Then MyBase.DescriptionValue = localizedDescription
                Catch
                    MyBase.DescriptionValue = String.Empty
                End Try
                Return MyBase.Description
            End Get
        End Property

    End Class

End Namespace