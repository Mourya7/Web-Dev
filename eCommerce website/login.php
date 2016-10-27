<?php
    include 'LIB_project1.php';
    echo getHtmlStartTag();
    echo getHtmlHead();
    echo getBodyStartTag();
    
    echo getLoginForm();
    
    echo getBodyEndTag();
    echo getHtmlEndTag();

    include 'validator.php';

?>