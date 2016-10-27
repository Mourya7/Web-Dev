<?php
    session_start();
    
    if(isset($_SESSION['loggedIn']))
    {
        include 'LIB_project1.php';
        echo getHtmlStartTag();
        echo getHtmlHead();
        echo getBodyStartTag();
        echo getAdminNavigatorBar();
        echo getBodyEndTag();
        echo getHtmlEndTag(); 
        
        require_once("DB.class.php");
        if(isset($_GET['id']))
        {
            $id = $_GET['id'];
            echo getAddedMessage($id);
        }
        else if(isset($_GET['uid']))
        {
            $id = $_GET['uid'];
            echo getUpdatedMessage($id);
        }
        $db = new DB();
        $data = $db->getAllProductsAsCatalogForAdmin(); 
        echo displayTable($data,"adminCatalog");
        
    }	
	else 
    {
        
        unset($_SESSION['loggedIn']);
        session_unset();
		session_destroy();
        header("Location:login.php");
        exit();
    }
     
?>