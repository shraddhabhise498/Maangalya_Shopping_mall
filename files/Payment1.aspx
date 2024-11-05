<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payment1.aspx.cs" Inherits="Payment1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>tailor</title>
    
    <style>
        body {
            margin: 0;
            padding: 0;
            background: #7EC8E3;
            background-size: cover;
            font-family: sans-serif;
        }

        .loginBox {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%,-50%);
            width: 350px;
            height: 350px;
            padding: 80px 40px;
            box-sizing: border-box;
            background: rgba(0,0,0,.5);
             border-radius:15px;
        }

        .sanBox {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%,-50%);
            width: 600px;
            height: 400px;
            padding: 80px 40px;
            box-sizing: border-box;
            background: rgba(0,0,0,.5);
        }


        .menuBox {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%,-50%);
            width: 1040px;
            height: 500px;
            padding: 80px 40px;
            box-sizing: border-box;
            background: rgba(0,0,0,.5);
        }

        .mapBox {
            position: absolute;
            top: 60%;
            left: 50%;
            transform: translate(-50%,-50%);
            width: 1280px;
            height: 600px;
            padding: 80px 40px;
            box-sizing: border-box;
            background: rgba(0,0,0,.5);
        }

        .user {
            width: 100px;
            height: 100px;
            border-radius: 50%;
            overflow: hidden;
            position: absolute;
            top: calc(-100px/2);
            left: calc(50% - 50px);
        }

        h2 {
            margin: 0;
            padding: 0 0 20px;
            color: #efed40;
            text-align: center;
        }

        h3 {
            color: #efed40;
        }

        h1 {
            color: #efed40;
            text-align: center;
        }

        .loginBox p {
            margin: 0;
            padding: 0;
            font-weight: bold;
            color: #fff;
        }

        .loginBox input {
            width: 100%;
            margin-bottom: 20px;
        }

            .loginBox input[type="text"],
            .loginBox input[type="password"] {
                border: none;
                border-bottom: 1px solid #fff;
                background: transparent;
                outline: none;
                height: 40px;
                color: #fff;
                font-size: 16px;
            }

        ::placeholder {
            color: rgba(255,255,255,.5);
        }

        .loginBox input[type="submit"] {
            border: none;
            outline: none;
            height: 40px;
            color: #fff;
            font-size: 16px;
            background: #ff267e;
            cursor: pointer;
            border-radius: 20px;
             margin-left:80px;
        }

            .loginBox input[type="submit"]:hover {
                background: #efed40;
                color: #262626;
            }

        .loginBox a {
            color: #fff;
            font-size: 14px;
            font-weight: bold;
            text-decoration: none;
        }

        ul {
            list-style-type: none;
            margin: 0;
            padding: 10px;
            overflow: hidden;
            background-color: #333;
        }

        li {
            float: right;
        }

            li a {
                display: inline-block;
                color: white;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
            }

                li a:hover {
                    background-color: skyblue;
                }

        .active {
            background-color: red;
        }
    </style>
    <style>
        .center {
            margin: auto;
            width: 50%;
            padding: 90px;
            color: red;
        }
    </style>
    <meta charset="utf-8">
 


</head>


<body >

    <div class="loginBox" style="height: 60%">
    <form id="form2" runat="server">
        <img src="img/pay.jpg" class="user" alt="ECS" />
            <h2>Final Checkout Page</h2>
    <div id ="frmError" runat="server">
      <span style="color:red">Please fill all mandatory fields.</span>
      <br/>
      <br/>
      </div>
      
    
   <input type="hidden" runat="server" id="key" name="key" />
      <input type="hidden" runat="server" id="hash" name="hash"  />
            <input type="hidden" runat="server" id="txnid" name="txnid" />
     
        
          <asp:TextBox ID="amount" runat="server" ReadOnly="true" />
       
           <asp:TextBox ID="firstname" runat="server" ReadOnly="true"/>
       
           <asp:TextBox ID="email" runat="server" ReadOnly="true" />
     
        
          <asp:TextBox ID="phone" runat="server"  ReadOnly="true"/>
        
         
          <asp:HiddenField  ID="productinfo"  runat="server" />
      
        
          <asp:HiddenField ID="surl" runat="server" />
        
         
          <asp:HiddenField ID="furl" runat="server" />
       
           
            
     
    
     <br />
      <asp:Button ID="submit" Text="PAY NOW" Width="100px"  runat="server" OnClick="Button1_Click"  />
    </form>
          
        
   
              </div>
</body>

   
  
</html>


