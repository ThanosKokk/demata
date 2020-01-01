@Code
    ViewData("Title") = "Home"
End Code
<link href="~/content/pricing.css" rel="stylesheet">
<div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
    @*<h1 class="display-4">Demata.gr</h1>*@
    <img src="~/img/demata_logo_opaque_450.jpg" class="img-responsive" />
    <p class="lead">Discover a new way to send parcels to your beloved ones, easily, fast and affordable!</p>
</div>

<form id="form" method="post" action="">
    <div class="form-row">
        <div class="form-group col-md-4">
            <label for="inputOrigin">Parcel Origin:</label>
            <select name="origin" id="inputOrigin" class="form-control" required>
                <option value="" selected disabled>Choose...</option>
                <option id="Albania" value="Albania">Albania</option>
                <option id="Austria" value="Austria">Austria</option>
                <option id="Belarus" value="Belarus">Belarus</option>
                <option id="Belgium" value="Belgium">Belgium</option>
                <option id="Bosnia and Herzegovina" value="Bosnia and Herzegovina">Bosnia and Herzegovina</option>
                <option id="Bulgaria" value="Bulgaria">Bulgaria</option>
                <option id="Croatia" value="Croatia">Croatia</option>
                <option id="Cyprus" value="Cyprus">Cyprus</option>
                <option id="Czech Republic" value="Czech Republic">Czech Republic</option>
                <option id="Denmark" value="Denmark">Denmark</option>
                <option id="Estonia" value="Estonia">Estonia</option>
                <option id="Finland" value="Finland">Finland</option>
                <option id="France" value="France">France</option>
                <option id="Georgia" value="Georgia">Georgia</option>
                <option id="Germany" value="Germany">Germany</option>
                <option id="Greece" value="Greece">Greece</option>
                <option id="Hungary" value="Hungary">Hungary</option>
                <option id="Iceland" value="Iceland">Iceland</option>
                <option id="Ireland" value="Ireland">Ireland</option>
                <option id="Italy" value="Italy">Italy</option>
                <option id="Latvia" value="Latvia">Latvia</option>
                <option id="Liechtenstein" value="Liechtenstein">Liechtenstein</option>
                <option id="Lithuania" value="Lithuania">Lithuania</option>
                <option id="Luxembourg" value="Luxembourg">Luxembourg</option>
                <option id="Macedonia" value="Macedonia">Macedonia</option>
                <option id="Malta" value="Malta">Malta</option>
                <option id="Moldova" value="Moldova">Moldova</option>
                <option id="Monaco" value="Monaco">Monaco</option>
                <option id="Montenegro" value="Montenegro">Montenegro</option>
                <option id="Netherlands" value="Netherlands">Netherlands</option>
                <option id="Norway" value="Norway">Norway</option>
                <option id="Poland" value="Poland">Poland</option>
                <option id="Portugal" value="Portugal">Portugal</option>
                <option id="Romania" value="Romania">Romania</option>
                <option id="Serbia" value="Serbia">Serbia</option>
                <option id="Slovakia" value="Slovakia">Slovakia</option>
                <option id="Slovenia" value="Slovenia">Slovenia</option>
                <option id="Spain" value="Spain">Spain</option>
                <option id="Sweden" value="Sweden">Sweden</option>
                <option id="Switzerland" value="Switzerland">Switzerland</option>
                <option id="Turkey" value="Turkey">Turkey</option>
                <option id="United Kingdom" value="United Kingdom">United Kingdom</option>
            </select>
        </div>
        <div class="form-group col-md-4">
            <label for="inputDestination">Parcel Destination</label>
            <select name="destination" id="inputDestination" class="form-control" required>
                <option value="" selected disabled>Choose...</option>
                <option id="Albania" value="Albania">Albania</option>
                <option id="Austria" value="Austria">Austria</option>
                <option id="Belarus" value="Belarus">Belarus</option>
                <option id="Belgium" value="Belgium">Belgium</option>
                <option id="Bosnia and Herzegovina" value="Bosnia and Herzegovina">Bosnia and Herzegovina</option>
                <option id="Bulgaria" value="Bulgaria">Bulgaria</option>
                <option id="Croatia" value="Croatia">Croatia</option>
                <option id="Cyprus" value="Cyprus">Cyprus</option>
                <option id="Czech Republic" value="Czech Republic">Czech Republic</option>
                <option id="Denmark" value="Denmark">Denmark</option>
                <option id="Estonia" value="Estonia">Estonia</option>
                <option id="Finland" value="Finland">Finland</option>
                <option id="France" value="France">France</option>
                <option id="Georgia" value="Georgia">Georgia</option>
                <option id="Germany" value="Germany">Germany</option>
                <option id="Greece" value="Greece">Greece</option>
                <option id="Hungary" value="Hungary">Hungary</option>
                <option id="Iceland" value="Iceland">Iceland</option>
                <option id="Ireland" value="Ireland">Ireland</option>
                <option id="Italy" value="Italy">Italy</option>
                <option id="Latvia" value="Latvia">Latvia</option>
                <option id="Liechtenstein" value="Liechtenstein">Liechtenstein</option>
                <option id="Lithuania" value="Lithuania">Lithuania</option>
                <option id="Luxembourg" value="Luxembourg">Luxembourg</option>
                <option id="Macedonia" value="Macedonia">Macedonia</option>
                <option id="Malta" value="Malta">Malta</option>
                <option id="Moldova" value="Moldova">Moldova</option>
                <option id="Monaco" value="Monaco">Monaco</option>
                <option id="Montenegro" value="Montenegro">Montenegro</option>
                <option id="Netherlands" value="Netherlands">Netherlands</option>
                <option id="Norway" value="Norway">Norway</option>
                <option id="Poland" value="Poland">Poland</option>
                <option id="Portugal" value="Portugal">Portugal</option>
                <option id="Romania" value="Romania">Romania</option>
                <option id="Serbia" value="Serbia">Serbia</option>
                <option id="Slovakia" value="Slovakia">Slovakia</option>
                <option id="Slovenia" value="Slovenia">Slovenia</option>
                <option id="Spain" value="Spain">Spain</option>
                <option id="Sweden" value="Sweden">Sweden</option>
                <option id="Switzerland" value="Switzerland">Switzerland</option>
                <option id="Turkey" value="Turkey">Turkey</option>
                <option id="United Kingdom" value="United Kingdom">United Kingdom</option>

            </select>
        </div>
        <div class="form-group col-md-4">
            <label for="inputWeight">Parcel weight:</label>
            <div class="input-group">
                <input type="number" required min="0" max="30" step=".1" class="form-control" id="inputWeight" name="weight">
                <div class="input-group-append">
                    <span class="input-group-text" id="basic-addon2">Kg</span>
                </div>
            </div>
        </div>
    </div>
    <div class="form-row">
        <div class="col-auto">
            <button type="submit" class="btn btn-primary mb-2">Submit</button>
        </div>
    </div>
</form>

<div style="display: none" class="container">
    <div class="card-deck mb-3 text-center">
        <div class="card mb-4 shadow-sm">
            <div class="card-header">
                <h4 class="my-0 font-weight-normal">Free</h4>
            </div>
            <div class="card-body">
                <h1 class="card-title pricing-card-title">$0 <small class="text-muted">/ mo</small></h1>
                <ul class="list-unstyled mt-3 mb-4">
                    <li>10 users included</li>
                    <li>2 GB of storage</li>
                    <li>Email support</li>
                    <li>Help center access</li>
                </ul>
                <button type="button" class="btn btn-lg btn-block btn-outline-primary">Sign up for free</button>
            </div>
        </div>
        <div class="card mb-4 shadow-sm">
            <div class="card-header">
                <h4 class="my-0 font-weight-normal">Pro</h4>
            </div>
            <div class="card-body">
                <h1 class="card-title pricing-card-title">$15 <small class="text-muted">/ mo</small></h1>
                <ul class="list-unstyled mt-3 mb-4">
                    <li>20 users included</li>
                    <li>10 GB of storage</li>
                    <li>Priority email support</li>
                    <li>Help center access</li>
                </ul>
                <button type="button" class="btn btn-lg btn-block btn-primary">Get started</button>
            </div>
        </div>
        <div class="card mb-4 shadow-sm">
            <div class="card-header">
                <h4 class="my-0 font-weight-normal">Enterprise</h4>
            </div>
            <div class="card-body">
                <h1 class="card-title pricing-card-title">$29 <small class="text-muted">/ mo</small></h1>
                <ul class="list-unstyled mt-3 mb-4">
                    <li>30 users included</li>
                    <li>15 GB of storage</li>
                    <li>Phone and email support</li>
                    <li>Help center access</li>
                </ul>
                <button type="button" class="btn btn-lg btn-block btn-primary">Contact us</button>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">

    //$.validator.setDefaults({
    //		submitHandler: function () {
    //			alert( "submitted!" );
    //		}
    //	});
    $(document).ready(function () {

        //$("#form").validate({
        //	rules: {
        //	origin: {
        //		required: true,
        //			depends: function(element)
        //			{
        //			return $("#inputOrigin").value!='';
        //			}
        //	},
        //	destination: {
        //		required: true,
        //		 depends: function(element) {
        //			return $("#inputDestination").value!='';
        //		 }
        //	},
        //	messages: {
        //	origin: "Please select a country of origin",
        //	destination: "Please select a country of destination",
        //	weight: "Please input a numerical value between 1 and 30"
        //		},
        //	errorElement: "em",
        //	errorPlacement: function ( error, element ) {
        //		error.addClass( "help-block" );
        //		error.insertAfter( element );
        //	},
        //	highlight: function ( element, errorClass, validClass ) {
        //			$( element ).parents( ".col-sm-5" ).addClass( "has-error" ).removeClass( "has-success" );
        //		},
        //	unhighlight: function (element, errorClass, validClass) {
        //			$( element ).parents( ".col-sm-5" ).addClass( "has-success" ).removeClass( "has-error" );
        //		}
        //		}
        //});

        function loadDoc() {
            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    var result = this.responseText;
                }
            };
            xhttp.open("GET", "../App_Data/costs.txt", true);
            xhttp.send();
            return result;
        }

        $("#form").submit(function (event) {
            var $inputs = $('form :input');
            var values = {};
            event.preventDefault();
            $inputs.each(function () {
                values[this.name] = $(this).val();
            });
            console.log('origin: ' + values.origin + ' dest: ' + values.destination + ' w: ' + values.weight);

            var dataValue = { "origin": values.origin, "destination": values.destination, "weight": values.weight};
            $.ajax({
                type: "GET",
                url: "Home/getCost",
                data: dataValue,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    alert("We returned: " + result);
                }
            });
        });
    });
</script>
