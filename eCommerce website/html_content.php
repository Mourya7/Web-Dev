<?php

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

function getBodyEndTag()
{
    return "</body>";
}

function getHtmlStartTag()
{
    return "<html>";
}

function getHtmlEndTag()
{
    return "</html>";
}

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
                        <a class='navbar-brand' href='#'> My awesome website</a>
                    </div>
                    <div class='collapse navbar-collapse' id='menu'>
                        <ul class='nav navbar-nav'>
                            <li><a href='#'>Home</a></li>
                            <li><a href='#'>About me</a></li>
                            <li><a href='#'>Contact me</a></li>
                            <li><a href='#'>Login</a></li>
                        </ul>
                    </div> 
                </div>
            </nav>
        </div>";
}

function getProducts()
{
    return "<div id='templatemo_wrapper'>
            <div> 
                <div class='cleaner'></div>
            </div>
                <div id='templatemo_main'>
                    <div id='content' class='float_l'>
                        <h1>New Products</h1>
                        <div class='product_box'>
                            <a href='productdetail.html'><img src='images/product/01.jpg' alt='Image 01' /></a>
                            <h3>Integer eleifend sed</h3>
                            <p class='product_price'>$ 100</p>
                            <a href='shoppingcart.html' class='add_to_card'>Add to Cart</a>
                            <a href='productdetail.html' class='detail'>Detail</a>
                        </div>        	
                        <div class='product_box'>
                            <a href='productdetail.html'><img src='images/product/02.jpg' alt='Image 02' /></a>
                            <h3>Nam cursus facilisis</h3>
                            <p class='product_price'>$ 200</p>
                            <a href='shoppingcart.html' class='add_to_card'>Add to Cart</a>
                            <a href='productdetail.html' class='detail'>Detail</a>
                        </div>        	
                        <div class='product_box no_margin_right'>
                            <a href='productdetail.html'><img src='images/product/03.jpg' alt='Image 03' /></a>
                            <h3>Mauris consectetur</h3>
                            <p class='product_price'>$ 120</p>
                            <a href='shoppingcart.html' class='add_to_card'>Add to Cart</a>
                            <a href='productdetail.html' class='detail'>Detail</a>
                        </div>        	
                        <div class='product_box'>
                            <a href='productdetail.html'><img src='images/product/04.jpg' alt='Image 04' /></a>
                            <h3>Proin volutpat</h3>
                            <p class='product_price'>$ 260</p>
                            <a href='shoppingcart.html' class='add_to_card'>Add to Cart</a>
                            <a href='productdetail.html' class='detail'>Detail</a>
                        </div> 
                        <div class='product_box'>
                            <a href='productdetail.html'><img src='images/product/05.jpg' alt='Image 05' /></a>
                            <h3>Proin volutpat</h3>
                            <p class='product_price'>$ 260</p>
                            <a href='shoppingcart.html' class='add_to_card'>Add to Cart</a>
                            <a href='productdetail.html' class='detail'>Detail</a>
                        </div> 
                    </div> 
                </div> 
            </div>";
}


?>
