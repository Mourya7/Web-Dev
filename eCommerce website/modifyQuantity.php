<?php

    require_once("DB.class.php");
    
    $db = new DB();
    $id = $_GET["id"];
    $quantity = $_GET["quantity"]-1;
    
    if(empty($_GET["id"]))
    {
        header('Location: index.php');
    }
    else
    {
        $db->updateQuantity(array("id"=>$id,"quantity"=>$quantity));
        //addToCart($id);
        $data = $db->getVacationPackage($id);
        if(count($data) > 0)
        {
                foreach($data as $row)
                {       
                    if($row['sale'])
                    {
                        $db->insertToCart($row['name'],$row['description'],$row['saleCost'],"1"); 
                    }
                    else
                    {
                        $db->insertToCart($row['name'],$row['description'],$row['cost'],"1"); 
                    }
                      
				}
        }
        header('Location: index.php');        
    }
?>