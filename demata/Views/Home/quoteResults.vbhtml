@ModelType List(Of demata.offerItem)
@Code
    ViewData("Title") = "quoteResults"
End Code

<h2>Results for your query</h2>

<div class="card">
    <h5 class="card-header">Express Deliveries</h5>
    <div class="card-body">
        @*<h5 class="card-title">Special title treatment</h5>*@
        @For Each itm In Model
            @<p Class="card-text">
                 <div Class="row">
                     <div Class="col-2">
                         <div Class="row">
                             <div class="col-5"><img src="~/img/@itm.supplierIcon" width="70"  /></div>
                             <div class="col-7">@itm.supplierService</div>
                             </div>
                         </div>
                     <div Class="col-2">
                         <div Class="row">
                             <div class="col-4"><img src="~/img/@itm.collectionIcon" width="50" class="pull-left" /></div>
                             <div class="col-8">@itm.collectionDescription</div>
                             </div>
                         </div>
                     <div Class="col-2">
                         <div Class="row">
                             <div class="col-4"><img src="~/img/truck.png" width="50" class="pull-left" /></div>
                             <div class="col-8">@itm.deliverytext</div>
                             </div>
                         </div>                         
                         <div Class="col-2">
                             <div Class="row">
                                 <div class="col-4"><img src="~/img/protection.png" width="50" class="pull-left" /></div>
                                 <div class="col-8">@itm.coverText</div>
                                 </div>
                             </div>
                         <div Class="col-2">
                             <div Class="row">
                                 <div class="col-4"><img src="~/img/printer.png" width="50" class="pull-left" /></div>
                                 <div class="col-8">@itm.printerText</div>
                                 </div>
                             </div>
                         <div Class="col-1">
                             @itm.price  &euro;
                         </div>
                             <div Class="col-1"><a href="#" class="btn btn-primary">Book!</a></div>
                         </div>
        </p>
        Next
    </div>
</div>