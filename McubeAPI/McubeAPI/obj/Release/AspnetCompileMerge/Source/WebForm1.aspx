<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="McubeAPI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript">
        function test() {
            var name = document.getElementById('_VIEWSTATE').value;
            alert(name)
        }
 </script>
    
 <script type="text/javascript">
   
     $('#form1').submit(function () {
         var product = { 'Id': 12, 'Name': 'Maya', 'Category': 'newcat', 'Price': 1234 };
        // $.post('/api/values', { value: 'Dave' });
         var Serial = $.post('/api/values', $('#status1').val())
             .success(function () {
                 var path = customer.getResponseHeader('Location');
                 var i = $('<a/>', { href: path, text: path });
                 $('#message').html(i);
             })
             .error(function () {
                 $('#message').html("Error for changes.");
             });
         return false;
     });

</script>
    <title></title>
</head>
<body>
     <form id="form1" action="http://localhost:63904/api/values" method="post" enctype="application/x-www-form-urlencoded">
    <div>
      <input id="status1" type="text" />
     
           <input type="submit"/>
        <input id="btnSubmit" type="submit" value="Submit data using POST" />
    </div>
    </form>
</body>
</html>
