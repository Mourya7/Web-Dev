<?php
    include 'LIB_project1.php';
    
    echo getHtmlStartTag();
    echo getHtmlHead();
    echo getBodyStartTag();
    
    echo getNavigatorBar();
    require_once("DB.class.php");

    $db = new DB();
    $data = $db->getAllProductsAsOnSale();
    echo displayTable($data,"userSale");

    $data = "";
    $page = isset($_GET['page'])?(int)$_GET['page'] : 1;
    $perPage = 5;
    
    $pagesForCatalogDisplay = $db->displayNumberOfPagesAssist($perPage);

    if($page > $pagesForCatalogDisplay)
    {
        $page = 1;
    }
    echo displayPagination($pagesForCatalogDisplay);
    $data = $db->getAllProductsAsCatalogForUser($page,$perPage); 
    
    
    echo displayTable($data,"userCatalog");
    echo displayPagination($pagesForCatalogDisplay);
    
    echo getBodyEndTag();
    echo getHtmlEndTag(); 
?>