<?php

    require_once("DB.class.php");
    $db = new DB();
    $db->deleteFromCart();
    header('Location: cart.php');

?>