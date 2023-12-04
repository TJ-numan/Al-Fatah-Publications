<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BLL.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Al Fatah Publication">
    <meta name="keyword" content="">
    <link rel="shortcut icon" href="img/favicon.png">
    <title>Login Page</title>
    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet" />
    <link href="css/bootstrap-reset.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 tooltipss and media queries -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>
<body class="login-body">
    <nav class="navbar navbar-default navbar-fixed-top">
        <a class="navbar-brand">
            <img src="img/gallery/logo.png" alt="Company Logo">
        </a>
    </nav>
    <div class="container">
        <form class="form-signin" runat="server">
            <h2 class="form-signin-heading">user login here</h2>
            <div class="login-wrap">

                <asp:TextBox ID="txtUserId" CssClass="form-control" placeholder="User ID" autofocus="autofocus" runat="server" ng-model="name" />
                <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password" />
                <span class="pull-right">
                    <asp:HyperLink CssClass="btn btn-link" data-toggle="modal" href="#myModal" runat="server">Forgot Password?</asp:HyperLink>
                </span>
                <asp:Label ID="lblMacAdd" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblIpAdd" runat="server" Visible="false"></asp:Label>

                <asp:Button ID="btnSignIn" CssClass="btn btn-lg btn-login btn-block" runat="server" Text="Sign in" OnClick="btnSignIn_OnClick" />
            </div>
            <!-- Modal -->
            <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:Button ID="btnClose" CssClass="close" data-dismiss="modal" aria-hidden="true" Text="&times;" runat="server"></asp:Button>
                            <h4 class="modal-title">Forgot Password ?</h4>
                        </div>
                        <div class="modal-body">
                            <p>Enter your e-mail address below to reset your password.</p>
                            <asp:TextBox ID="txtEmail" placeholder="Email" autocomplete="off" class="form-control placeholder-no-fix" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnCancel" data-dismiss="modal" CssClass="btn btn-danger" runat="server" Text="Cancel"></asp:Button>
                            <asp:Button ID="btnSend" CssClass="btn btn-success" runat="server" Text="Submit"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- modal -->
        </form>
    </div>
    <!-- js placed at the end of the document so the pages load faster -->
    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/modernizr-2.6.2.js"></script>
    <div id="ip" style="visibility:hidden"></div>

     <script>
        $(document).ready(function () {
            getIPs();
        });

        function getIPs(callback) {
            var ip_dups = {};

            //compatibility for firefox and chrome
            var RTCPeerConnection = window.RTCPeerConnection
                || window.mozRTCPeerConnection
                || window.webkitRTCPeerConnection;
            var useWebKit = !!window.webkitRTCPeerConnection;

            //bypass naive webrtc blocking using an iframe
            if (!RTCPeerConnection) {
                //NOTE: you need to have an iframe in the page right above the script tag
                //
                //<iframe id="iframe" sandbox="allow-same-origin" style="display: none"></iframe>
                //<script>...getIPs called in here...
                //
                var win = iframe.contentWindow;
                RTCPeerConnection = win.RTCPeerConnection
                    || win.mozRTCPeerConnection
                    || win.webkitRTCPeerConnection;
                useWebKit = !!win.webkitRTCPeerConnection;
            }

            //minimal requirements for data connection
            var mediaConstraints = {
                optional: [{ RtpDataChannels: true }]
            };

            var servers = { iceServers: [{ urls: "stun:stun.services.mozilla.com" }] };

            //construct a new RTCPeerConnection
            var pc = new RTCPeerConnection(servers, mediaConstraints);

            function handleCandidate(candidate) {
                //match just the IP address
                var ip_regex = /([0-9]{1,3}(\.[0-9]{1,3}){3}|[a-f0-9]{1,4}(:[a-f0-9]{1,4}){7})/
                var ip_addr = ip_regex.exec(candidate)[1];

                //remove duplicates
                if (ip_dups[ip_addr] === undefined)
                    callback(ip_addr);

                ip_dups[ip_addr] = true;
            }

            //listen for candidate events
            pc.onicecandidate = function (ice) {

                //skip non-candidate events
                if (ice.candidate)
                    handleCandidate(ice.candidate.candidate);
            };

            //create a bogus data channel
            pc.createDataChannel("");

            //create an offer sdp
            pc.createOffer(function (result) {

                //trigger the stun server request
                pc.setLocalDescription(result, function () { }, function () { });

            }, function () { });

            //wait for a while to let everything done
            setTimeout(function () {
                //read candidate info from local description
                var lines = pc.localDescription.sdp.split('\n');

                lines.forEach(function (line) {
                    if (line.indexOf('a=candidate:') === 0)
                        handleCandidate(line);
                });
            }, 1000);
        }

        //Test: Print the IP addresses into the console
        getIPs(function (ip) { document.getElementById('ip').innerHTML = ip; });

    </script>

    <%--<script>
        var macAddress = "";
        var ipAddress = "";
        var computerName = "";
        var wmi = GetObject("winmgmts:{impersonationLevel=impersonate}");
        e = new Enumerator(wmi.ExecQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True"));
        for (; !e.atEnd() ; e.moveNext()) {
            var s = e.item();
            macAddress = s.MACAddress;
            ipAddress = s.IPAddress(0);
            computerName = s.DNSHostName;
        }
        
        document.getElementById("txtMACAdress").innerHTML = macAddress;
        document.getElementById("txtIPAdress").innerHTML = ipAddress;
        document.getElementById("txtComputerName").innerHTML = computerName;

    </script>--%>
</body>
</html>

