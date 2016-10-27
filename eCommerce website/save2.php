<?php
    include 'LIB_project1.php';
    $id = $name = $description = $cost = $sale = "";
    

    if ($_SERVER["REQUEST_METHOD"] == "POST"){
        $id = $_POST['packageID'];
        $name = $_POST['packageName'];
        $description = $_POST['description'];
        $originalPrice = $_POST['originalPrice'];
        $salePrice = $_POST['salePrice'];
        $sale = $_POST['sale'];
        
        sanitize($productName);
        sanitize($description);
        sanitize($cost);
        
        require_once("DB.class.php");
        $db = new DB();
        
        $fields = array("id"=>$id,"name"=>$name,"description"=>$description,"originalPrice"=>$originalPrice,"salePrice"=>$salePrice,"sale"=>$sale);
        var_dump($salePrice);
        
        if(validate_text($name)=="false" || validate_text($description)=="false")
        {
                  echo"<h3> Please enter appropriate data for text fields </h3>";
        }
        
        else if(validate_numbers($originalPrice)=="false" || validate_text($salePrice)=="false")
        {
                  echo"<h3> Please enter appropriate data for price fields </h3>";
        }
        
        else if($sale!="" && $sale=="1")
        {

            //echo $db->checkSaleAddConstraint($sale);

            if($db->checkSaleAddConstraint()==false)
            {
                header("Location:edit.php?id=$id&error=constraintError");
            }
            else
            {
                $insertID = $db->updateVacationPackages($fields);
                header("Location:admin.php?uid={$insertID}");
            }
        }

        else if($sale!="" && $sale=='0')
        {
            if($db->checkSaleDeleteConstraint()==false)
            {
                header("Location:edit.php?id=$id&error=constraintError");
            }
            
            else if($db->checkSaleDeleteConstraint()==true)
            {
                $insertID = $db->updateVacationPackages($fields);
                header("Location:admin.php?uid={$insertID}");
            }
        }
    }

    //sanitization
    function sanitize($data) {
      $data = trim($data);
      $data = stripslashes($data);
      $data = htmlspecialchars($data);
      return $data;
    }  
 
   function validate_text($data)
    {
        $reg = "/^[a-zA-Z]+$/";
        return preg_match($reg,$data);
    }

    function validate_numbers($data)
    {
        $reg = "/^^[0-9]*$/";
        return preg_match($reg,$data);
    }    
?>
