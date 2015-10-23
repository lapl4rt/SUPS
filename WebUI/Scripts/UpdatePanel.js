$(function() {
       $("#<%=CargoGridView.ClientID%> a").bind('click', function() {
           refreshUpdatePanel();
           alert("fds");
       });
   });

function refreshUpdatePanel()
{
    __doPostBack('CargoGVUpdatePanel', '');
}