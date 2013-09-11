Imports System.Resources


Namespace Ressource.localizable

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.All)> _
    Public Class LocalizableNameAtt
        Inherits System.ComponentModel.DisplayNameAttribute

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
            _ResourceManager = My.Resources.text.LocalizablePropertyNames.ResourceManager
        End Sub


        Public Overloads Overrides ReadOnly Property DisplayName() As String
            Get
                Try
                    Dim localizedDescription As String = _ResourceManager.GetString(MyBase.DisplayName)
                    If Not String.IsNullOrEmpty(localizedDescription) Then MyBase.DisplayNameValue = localizedDescription
                Catch
                    MyBase.DisplayNameValue = String.Empty
                End Try
                Return MyBase.DisplayName
            End Get
        End Property

    End Class

End Namespace
