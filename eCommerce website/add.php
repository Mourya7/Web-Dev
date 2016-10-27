<?php
    session_start();
    
    if(isset($_SESSION['loggedIn']))
    {
        
        include 'LIB_project1.php';
        echo getHtmlStartTag();
        echo getHtmlHead();
        echo getBodyStartTag();
        if($_GET['error']=="constraintError")
        {
            echo getConstraintError();
        }
        else if($_GET['error']=="salePriceError")
        {
            echo getSalePriceError();
        }
        else if($_GET['error']=="ProblemWithFile" || $_GET['error']=="FileTypeError")
        {
            echo getFileUploadError();
        }
        else if($_GET['error']=="formError")
        {
            echo getFormDataError();
        }
        echo getAdminNavigatorBar();
        echo getAddForm($id);
        echo getBodyEndTag();
        echo getHtmlEndTag(); 
    }

    else 
    {
        unset($_SESSION['loggedIn']);
        session_unset();
		session_destroy();
        header("Location:login.php");
    }

    
 ?>