<?php
    session_start();

    if(isset($_SESSION['loggedIn']))
    {
        unset($_SESSION['loggedIn']);
        session_unset();
        session_destroy();
   
    }
    
     header('Location: login.php');
?> 