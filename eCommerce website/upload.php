<?php

if(!empty($_FILES['uploaded_file']) && $_FILES['uploaded_file']['error']==0){
    
    //check fr size and type
    $filename = basename($_FILES['uploaded_file']['name']);
    $ext = substr($filename,strrpos($filename,'.')+1);
    var_dump(strrpos($filename,'.'));
    echo ($ext);
    
    if($ext=="jpg" && $_FILES['uploaded_file']['type']=="application/.jpg" && 
                       $_FILES['uploaded_file']['size'] < 350000)
    {
        $newname = "./files/$filename";
        if(move_uploaded_file($_FILES['uploaded_file']['tmp_name'],$newname)){
            chmod($newname,0644);
            $msg = "Success!";
        }
            
        else{
            $msg = "Error:Problem uploading files!";
        }
    }
    else
    { 
        $msg = "Error:Only .xls files under 350k are allowed!";
    }
}else
{
    $msg = "Error:No file uploaded!";
}

?>