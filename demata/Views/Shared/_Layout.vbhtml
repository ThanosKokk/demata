﻿<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title|demata.gr</title>
    <link href="~/favicon.png" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="../../assets/js/vendor/holder.min.js"></script>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/bundles/jqueryval")
</head>
<body>

    <div class="d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-light border-bottom shadow-sm">
        <h5 class="my-0 mr-md-auto font-weight-normal">@Html.ActionLink("Demata.gr", "Index", "Home")</h5>
        <nav Class="my-2 my-md-0 mr-md-3">
            <a Class="p-2 text-dark" href="#">I need a Quote!</a>
            <a Class="p-2 text-dark" href="#">Tracking</a>
            <a Class="p-2 text-dark" href="#">Our Services</a>
            <a Class="p-2 text-dark" href="#">Basket<i class="fa fa-shopping-cart"></i></a>
        </nav>
        <button type="button" class="btn btn-outline-primary" data-toggle="modal" data-target="#signinModal">
            Sign In
        </button>
    </div>


    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer class="pt-4 my-md-5 pt-md-5 bg-light border-top">
            <div class="row">
                <div class="col-12 col-md">
                    <img class="mb-2" src="~/img/favicon.png" alt="" width="24" height="24">
                    <small class="d-block mb-3 text-muted">&copy; 2019-2020</small>
                </div>
                <div class="col-6 col-md">
                    <h5>About us</h5>
                    <ul class="list-unstyled text-small">
                        <li><a class="text-muted" href="#">Our company</a></li>
                        <li><a class="text-muted" href="#">Our vision</a></li>
                        <li><a class="text-muted" href="#">Terms and conditions</a></li>
                        <li><a class="text-muted" href="#">Careers</a></li>
                        <li><a class="text-muted" href="#">GDPR</a></li>
                    </ul>
                </div>
                <div class="col-6 col-md">
                    <h5>Coverage</h5>
                    <ul class="list-unstyled text-small">
                        <li><a class="text-muted" href="#">North Europe</a></li>
                        <li><a class="text-muted" href="#">North America</a></li>
                        <li><a class="text-muted" href="#">Asia</a></li>
                        <li><a class="text-muted" href="#">Australia</a></li>
                    </ul>
                </div>
                <div class="col-6 col-md">
                    <h5>Need help?</h5>
                    <ul class="list-unstyled text-small">
                        <li><a class="text-muted" href="#">FAQs</a></li>
                        <li><a class="text-muted" href="#">My account</a></li>
                        <li><a class="text-muted" href="#">Parcel tracking</a></li>
                        <li><a class="text-muted" href="#">Privacy</a></li>
                        <li><a class="text-muted" href="#">Terms</a></li>
                    </ul>
                </div>
            </div>
        </footer>
    </div>

    <div class="modal fade" id="signinModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Sign In demata.gr</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form id="signinForm" action="" method="post">
                        <div class="form-group">
                            <input type="text" class="form-control" id="username" aria-describedby="usernameHelp" placeholder="Username" />
                            <small id="usernameHelp" class="form-text text-muted">Please provide your username.</small>
                        </div>
                        <div class="form-group">
                            <input type="password" class="form-control" id="password" aria-describedby="passwordHelp" placeholder="Password" />
                            <small id="passwordHelp" class="form-text text-muted">Please provide your password.</small>
                        </div>
                        <div class="form-group">
                            <input type="checkbox" class="form-check-input" id="rememberme" aria-describedby="remembermeHelp" />
                            <label class="form-check-label" for="rememberme">
                                Check to remember you next time.
                            </label>                            
                        </div>
                        <div class="form-group">
                            <input type="button" class="btn btn-outline-primary btn-lg btn-block" id="submit" value="Log in" />                           
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>                    
                </div>
            </div>
        </div>
    </div>

    <script>
        Holder.addTheme('thumb', {
            bg: '#55595c',
            fg: '#eceeef',
            text: 'Thumbnail'
        });
    </script>

    @RenderSection("scripts", required:=False)
</body>
</html>
