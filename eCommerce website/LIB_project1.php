<?php
//include "vacationpackage.class.php";
function getHtmlHead()
{
    return "<head>
        <meta nam='viewport' content='width=device-width,initial-scale=1'>
        <title>Plan your vacation!</title>
        <link rel='stylesheet' href='css/bootstrap.min.css'>
        <link href='css/templatemo_style.css' rel='stylesheet' type='text/css' />
        <script src='http://code.jquery.com/jquery-latest.min.js'></script>
        <script src='js/bootstrap.js'></script>
    </head>";
}
function getBodyStartTag()  
{
    return "<body>";  
}

//returns body start tag

function getBodyEndTag()
{
    return "</body>";
}

//returns body end tag

function getHtmlStartTag()
{
    return "<html>";
}

//returns html start tag

function getHtmlEndTag()
{
    return "</html>";
}

//returns html end tag

function getNavigatorBar()
{
    return "<div class='container'>
            <nav class='navbar navbar-inverse'>
                <div class='container'>
                    <div class='navbar-header'>
                        <button type='button' class='navbar-toggle collapsed' data-toggle='collapse' data-target='#menu'>
                            <span class='icon-bar'></span>
                            <span class='icon-bar'></span>
                            <span class='icon-bar'></span>
                        </button>
                        <a class='navbar-brand' href=''> Holiday Inn tours and travels</a>
                    </div>
                    <div class='collapse navbar-collapse' id='menu'>
                        <ul class='nav navbar-nav'>
                            <li><a href='index.php'>Home</a></li>
                            <li><a href='login.php'>Login</a></li>
                            <li><a href='cart.php'>View my Cart</a></li>
                        </ul>
                    </div> 
                </div>
            </nav>
        </div>";
}

//returns index.php navigation bar

function getAdminNavigatorBar()
{
    return "<div class='container'>
            <nav class='navbar navbar-inverse'>
                <div class='container'>
                    <div class='navbar-header'>
                        <button type='button' class='navbar-toggle collapsed' data-toggle='collapse' data-target='#menu'>
                            <span class='icon-bar'></span>
                            <span class='icon-bar'></span>
                            <span class='icon-bar'></span>
                        </button>
                        <a class='navbar-brand' href=''>Welcome administrator!</a>
                    </div>
                    <div class='collapse navbar-collapse' id='menu'>
                        <ul class='nav navbar-nav'>
                            <li><a href='admin.php'>Home</a></li>
                            <li><a href='add.php'>Add</a></li>
                            <li><a href='logout.php'>Logout</a></li>
                        </ul>
                    </div> 
                </div>
            </nav>
        </div>";
}

//returns admin.php nav bar

function getLoginForm()
{
   return "<h2>Login Form</h2>

    <form action='login.php' method='POST'>
      <div class='container'>
        <label><b>Username</b></label>
        <input type='text' placeholder='Enter Username' name='uname' required>

        <label><b>Password</b></label>
        <input type='password' placeholder='Enter Password' name='pwd' required>

        <button type='submit'>Login</button>
      </div>
    </form>";
}

//returns login field for username and pwd input

function getClearCartButton()
{
    return "<a href='clearCart.php'><button type='button'>Clear cart!</button></a>";
}

//returns clear cart button 

function displayTotalPurchaseCost($totalPurchaseCost)
{
    return "<h4>Your total purchase cost is {$totalPurchaseCost}\n</h4>";
}

//returns total purchase value in html

function displayPagination($pagesForCatalogDisplay)
{
    $bigString = "<div class='pagination'>";
    for($x = 1; $x<=$pagesForCatalogDisplay;$x++)
    {
        $y = $x;
        $bigString .= "<a href='index.php?page={$y}'><button type='button'>{$y}</button></a>";
    }
    $bigString.='</div>';
    return $bigString;
    
}

//returns pagination buttons

function displayTable($data,$type)
{
    if($type=="cart")
    {
        if(count($data) > 0){
                    $bigString = "<section id='form'><table class='table table-responsive'>\n";
                    $bigString .="<tr><th>Name</th><th>Description</th>
                                  <th>Price</th><th>Quantity</th></tr>\n";

                    foreach($data as $row){
                            $bigString .=
                            "<tr><td>{$row['name']}</td>
                            <td>{$row['description']}</td><td>{$row['price']}</td>
                            <td>{$row['quantity']}</td></tr>\n";
                            $totalPurchaseCost += $row['price'];
                    }
                    $bigString .= "</table></section>\n"; 
                    $bigString .= "<h4>Your total purchase cost is {$totalPurchaseCost}\n</h4>";
                }else{
                    $bigString = "<h2>No items in cart!</h2>";
                }
        return $bigString;
    }
    
    else if($type=="userCatalog")
    {
        
        if(count($data) > 0){
				$bigString = "<section id='form'><table class='table table-responsive'>\n";
				$bigString .="<tr><th>Name</th><th>Description</th>
							  <th>Orginal Price</th><th>Quantity Left</th><th>Image</th><th>Sale Price</th></tr>\n";
							  
				foreach($data as $row){
                   
                        $bigString .="<tr><td>{$row['name']}</td>
                        <td>{$row['description']}</td><td>{$row['cost']}</td>
                        <td>{$row['quantity']}</td><td><img src='{$row['imagePath']}'style='width:320px;height:240px;'></td>
                        <td>{$row['saleCost']}</td><td><a href='modifyQuantity.php?id={$row['id']}&quantity={$row['quantity']}'>
                        <button type='button'>Add to Cart!</button></a></td></tr>\n";
				}
				$bigString .= "</table></section>\n";
                
			}else{
				$bigString = "<h2>No items found!</h2>";
			}
    }
    
    else if($type=="adminCatalog")
    {
        if(count($data) > 0)
        {
				$bigString = "<section id='form'><table class='table table-responsive'>\n";
				$bigString .="<tr><th>ID</th><th>Name</th><th>Description</th>
							  <th>Orginal Price</th><th>Quantity Left</th><th>Image</th><th>Discount</th><th>For Sale?</th></tr>\n";
							  
				foreach($data as $row)
                {
                        $row['sale']=='0'?$sale="No":$sale="Yes";
                        $bigString .=
					    "<tr><td>{$row['id']}</a></td><td>{$row['name']}</td>
                        <td>{$row['description']}</td><td>{$row['cost']}</td>
                        <td>{$row['quantity']}</td><td><img src='{$row['imagePath']}'style='width:320px;height:240px;'></td>
                        <td>{$row['saleCost']}</td><td>{$sale}</td>
                        <td><a href='edit.php?id={$row['id']}'><button type='button'>Edit Item</button></a></td></tr>\n";
				
				}
				$bigString .= "</table></section>\n"; 
        }
        else
        {
		      $bigString = "<h2>No items found!</h2>";
		}
    }
    
    else if($type=="userSale")
    {
            if(count($data) > 0)
            {
				$bigString = "<section id='form'><table class='table table-responsive'>\n";
				$bigString .="<tr><th>Name</th><th>Description</th>
							  <th>Orginal Price</th><th>Quantity Left</th><th>Image</th><th>Sale Price</th></tr>\n";
							  
				foreach($data as $row)
                {
                    if($row['sale']=="1" && ($row['quantity'] > 0))
                    {
                       $bigString .=
					  "<tr><td>{$row['name']}</td>
                        <td>{$row['description']}</td><td>{$row['cost']}</td>
                        <td>{$row['quantity']}</td><td><img src='{$row['imagePath']}'style='width:320px;height:240px;'></td>
                        <td>{$row['saleCost']}</td><td><a href='modifyQuantity.php?id={$row['id']}&quantity={$row['quantity']}'>
                        <button type='button'>Add to Cart!</button></a></td></tr>\n";
                    }
                }   
				$bigString .= "</table></section>\n"; 
			}
            else
            {
				$bigString = "<h2>No people found!</h2>";
            }    
    }
    
    return $bigString;
}

//returns tables for index.php (userCatalog and salesCatalog), admin.php(adminCatalog) and cart.php(cart table)

function getEditForm($id)
{
    return "<form method='post' action='save2.php'>
         <div class='form-group '>
             <label for='package ID'>Package ID</label>
             <input type='textbox' readonly value='{$id}' class='form-control' name='packageID'/>
             <input type='hidden' name='packageID' value='{$id}' />
         </div>
         <div class='form-group '>
             <label for='packageName' class='form-group '>Package Name</label>
             <input type='textbox' class='form-control' name='packageName'/>
         </div>
          <div class='form-group '>
             <label for='description' class='form-group '>Package Description</label>
             <input type='textbox' class='form-control' name='description'/>
         </div>
         <div class='form-group '>
             <label for='originalPrice' class='form-group '>original price</label>
             <input type='number' min='0' max='10000000000' class='form-control' name='originalPrice'/>
         </div>
         <div class='form-group '>
             <label for='saleprice' class='form-group '>sale price</label>
             <input type='number' min='0' max='10000000000' class='form-control' name='salePrice'/>
         </div>
         <div class='form-group '>
             <label for='sale'>Sale</label>
             <select name='sale' for='sale' class='form-control'>
                 <option value=''>
                     Select
                 </option>
                 <option value='0'>
                     No
                 </option>
                 <option value='1'> 
                     Yes
                 </option> 
             </select>
         </div>
         
         <button type='submit' class='center-block btn-lg btn-primary'>Save</button>
     </form>";
}

//returns edit form for admin

function getAddForm($id)
{
    return "<form method='post' action='save.php' enctype='multipart/form-data'> 
         <div class='form-group '>
             <label for='packageName' class='form-group '>Package Name</label>
             <input type='textbox' class='form-control' name='packageName'/>
         </div>
          <div class='form-group '>
             <label for='description' class='form-group '>Package Description</label>
             <input type='textbox' class='form-control' name='description'/>
         </div>
         <div class='form-group '>
             <label for='originalPrice' class='form-group '>original price</label>
             <input type='number' min='0' max='10000000000' class='form-control' name='originalPrice'/>
         </div>
         <div class='form-group '>
             <label for='quantity' class='form-group '>quantity</label>
             <input type='number' min='0' max='10000000000' class='form-control' name='quantity'/>
         </div>
         <div class='form-group '>
             <label for='saleprice' class='form-group '>sale price</label>
             <input type='number' min='0' max='10000000000' class='form-control' name='salePrice'/>
         </div>
         <div class='form-group '>
             <label for='sale'>Sale</label>
             <select name='sale' for='sale' class='form-control'>
                 <option value=''>
                     Select
                 </option>
                 <option value='0'>
                     No
                 </option>
                 <option value='1'> 
                     Yes
                 </option> 
             </select>
         </div>
         <label for='uploaded_file'>Choose a file to upload:</label><input name='uploaded_file'' id='uploaded_file' type='file' />
         <button type='submit' class='center-block btn-lg btn-primary'>Save</button>
     </form>";
}

//returns add form

function getConstraintError()
{
    return "<h3>Number of items on sale constraint is violated </h3>";
}

//returns constraint error

function getSalePriceError()
{
    return "<h3>Item on sale requires sale price!</h3>";
}

//returns sale price error

function getFileUploadError()
{
    return "<h3>Please verify the file you are uploading..(allowed type is 'image/jpeg'and size < 3MB)</h3>";
}

//returns file upload error

function getFormDataError()
{
    return "<h3> Fill in all the details for the vacation package </h3>";
}
//returns error if no data entered in form

function getUpdatedMessage($id)
{
    return "<h3> Vacation package {$id} is updated! </h3>";
}
//returns vacationpackage updated message

function getAddedMessage($id)
{
    return "<h3> Vacation package {$id} is added to your database! </h3>";
}
//returns new item added message

?>
