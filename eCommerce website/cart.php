<?php

include 'LIB_project1.php';
    

    echo getHtmlStartTag();
    echo getHtmlHead();
    echo getBodyStartTag();
    
    echo getNavigatorBar();
    require_once("DB.class.php");

    $db = new DB();
    $data = $db->getAllProductsFromCart();
    echo displayTable($data,"cart");

    echo getClearCartButton();
    
    echo getBodyEndTag();
    echo getHtmlEndTag();
  
?>