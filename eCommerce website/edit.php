<?php
    $id = $_GET['id'];
        
    include 'LIB_project1.php';
    echo getHtmlStartTag();
    echo getHtmlHead();
    echo getBodyStartTag();
    if(!isset($_GET['id']))
    {
        header('Location:admin.php');       
    }
    if($_GET['error']=="constraintError")
    {
        echo getConstraintError();
    }
    else if($_GET['error']=="salePriceError")
    {
        echo getSalePriceError();
    }
    echo getAdminNavigatorBar();
    echo getEditForm($id);
    
    echo getBodyEndTag();
    echo getHtmlEndTag(); 
 ?>
     
