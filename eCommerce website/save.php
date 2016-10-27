<?php
   //include 'LIB_project1.php';
    $id = $name = $description = $cost = $sale = "";
    

    if ($_SERVER["REQUEST_METHOD"] == "POST")
    {
        $id = $_POST['packageID'];
        $name = $_POST['packageName'];
        $description = $_POST['description'];
        $originalPrice = $_POST['originalPrice'];
        $quantity = $_POST['quantity'];
        $salePrice = $_POST['salePrice'];
        $sale = $_POST['sale'];
        $noError = true;
        
        $filename = basename($_FILES['uploaded_file']['name']);
        $ext = substr($filename,strrpos($filename,'.')+1);
        
        sanitize($productName);
        sanitize($description);
        sanitize($cost);
        
        require_once("DB.class.php");
        $db = new DB();
        
        if($name!="" && $description!="")
        {
              if(validate_text($name)=="false")
              {
                  echo"<h3> Please enter appropriate data for name field </h3>";
                  $noError = false;
              }
        }
        else
        {
          header("Location:add.php?id=$id&error=formError");
        }
        if($originalPrice!="" && $salePrice!="" && $quantity!="" && $sale!="")
        {
              if(validate_numbers($originalPrice)=="false" || validate_numbers($salePrice)=="false" || validate_numbers($quantity)=="false")
              {
                  echo"<h3> Please enter appropriate data for price fields </h3>";
                  $noError = false;
              }
        }
        else
        {
          header("Location:add.php?id=$id&error=formError");
        }
        
        if($sale!="" && $sale=="1")
        {
            if($db->checkSaleAddConstraint()==false)
            {
                header("Location:add.php?id=$id&error=constraintError");
            }

        }
        
        if(!empty($_FILES['uploaded_file']) && $_FILES['uploaded_file']['error']==0)
        {
                if(($ext=="jpg" || $ext=="JPG") && ($_FILES['uploaded_file']['type']=="image/jpeg") && 
                                   $_FILES['uploaded_file']['size'] < 3500000)
                {
                    $newname = "./images/$filename";
                    if(move_uploaded_file($_FILES['uploaded_file']['tmp_name'],$newname))
                    {
                        chmod($newname,0644);
                        $imagePath = $newname;
                    }

                    else{
                            header("Location:add.php?id=$id&error=ProblemWithFile");
                        }
                }
                else
                { 
                   header("Location:add.php?id=$id&error=FileTypeError");
                }
        }
        else
        {
            header("Location:add.php?id=$id&error=formError");
            var_dump($_FILES['uploaded_file']['type']);
        }
        
        if($noError = true)
        {
           $insertId = $db->addVacationPackages($name,$description,$originalPrice,$quantity,$imagePath,$salePrice,$sale);
           header("Location:admin.php?id={$insertId}");
        }
        
        }
    //sanitization
    function sanitize($data) 
    {
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
        $reg = "/^[0-9]+$/";
        return preg_match($reg,$data);
    }    
?>
