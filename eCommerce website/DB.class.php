    <?php
   
   // include "LIB_project1.php";
	class DB{
		
		private $connection;
        
		function __construct(){
			require_once("../../../dbinfo.php");
			$this->connection = new mysqli($host,$user,$pass,$db);
			if($this->connection->connect_error){
				echo "Connection failed: ".mysqli_connect_error();
				die();
			}
		
		
		}//constructor
	
	
		function getAllProducts(){
			$data = array();
			
			$stmt = $this->dbh->prepare('SELECT `name` FROM xmlrpc_product');
            $stmt->execute();
            if ($stmt->rowCount() > 0) 
            {
            $data = $stmt->fetchAll(PDO::FETCH_ASSOC);
            $productList = array();
            foreach ($data as $value)
            {
              $productList[] = $value['name'];
            }
            return $productList;
            }
            else 
            {
            return $productList = array();
            }
                return $data;	

        }//getAllProducts
        
        function displayNumberOfPagesAssist($perPage)
        {
            if ($stmt = $this->connection->prepare("select * from VacationPackages where sale = '0'")){
				$stmt->execute();
                $stmt->store_result();
               
                $total = $stmt->num_rows;
                
				$pagesForCatalogDisplay = ceil($total / $perPage);
                return $pagesForCatalogDisplay;
            }
        }//Pagination 
	       
		function getAllProductsAsCatalogForUser($page,$perPage){
            $data = array();
            
			$start = ($page>1)?($page*$perPage)-$perPage:'0';
            //$start=5;
            
            //echo $perPage;
			if ($stmt = $this->connection->prepare("select * from VacationPackages where sale = '0' limit {$start},{$perPage}")){
				$stmt->execute();
				$stmt->store_result();
				$stmt->bind_result($id,$name,$description,$cost,$quantity,$imagePath,$saleCost,$sale);
                
                /*$total = $stmt->num_rows;
				$pagesForCatalogDisplay = ceil($total / $perPage);*/
                
				//fetch rows
				if($stmt->num_rows>0){
					while($stmt->fetch()){
						$data[] = array("id"=>$id,
                                         "name"=>$name,
										 "description"=>$description,
										 "cost"=>$cost,
                                         "quantity"=>$quantity,
                                         "imagePath"=>$imagePath,
                                         "saleCost"=>$saleCost,
                                         "sale"=>$sale
                           ); 		 	
					} 
				}	
			}//all good
            
			return $data;	
		}//getAllPackagesAsTable
        
        function getAllProductsAsCatalogForAdmin(){
			$data = $this->getAllProducts();
			return $data; 
		} //getAllProductsforAdmin
        
        function getAllProductsAsOnSale(){
			$data = $this->getAllProducts();
			return $data;
		}//getAllProductsforUser
        
        function updateQuantity($fields){
			$queryString = "update VacationPackages set ";
			$insertId = 0;
			$numRows = 0;
			
			foreach($fields as $k=>$v){
				switch($k){
					case "quantity":
						$queryString .="Quantity = '$v',";
						break;	
					case "id":
						$insertId = intval($v);
						break;					 
				}//switch
			}//foreach
			
			$queryString = trim($queryString," ,");
			$queryString .= "where packageId = ?";
			
			if ($stmt = $this->connection->prepare($queryString)) {
				$stmt->bind_param("i",$insertId);
				$stmt->execute();
				$stmt->store_result();
				$numRows = $stmt->affected_rows;
			
			}
			
			return $numRows;
		
		}//update quantity in inde.php
        
        
        function updateVacationPackages($fields){
			$queryString = "update VacationPackages set ";
			$insertId = 0;
			$numRows = 0;
			
			foreach($fields as $k=>$v){
				switch($k){
					case "name":
                        if($v == "")
                            break;
						$queryString .="name = '$v',";
						break;	
                    case "description":
                        if($v == "")
                            break;
                        $queryString .="description = '$v',";
                        break;
                    case "originalPrice":
                        if($v == "")
                            break;
                        $queryString .="originalPrice = '$v',";
                        break;
                    case "salePrice":
                        if($v == "")
                            break;
                        $queryString .="salePrice = '$v',";
                        break;
                    case "sale":
                        if($v == "")
                            break;
                        $queryString .="sale = '$v',";
                        break;
                    case "id":
						$insertId = intval($v);
						break;					 
				}//switch
			}//foreach
			
			$queryString = trim($queryString," ,");
			$queryString .= "where packageId = ?";
			if ($stmt = $this->connection->prepare($queryString)) {
				$stmt->bind_param("i",$insertId);
				$stmt->execute();
				$stmt->store_result();
				$numRows = $stmt->affected_rows;
			
			}
			
			return $insertId;
		
		} //update for admin 
        
        function getVacationPackage($id){
			$data = array();
			if ($stmt = $this->connection->prepare("select * from VacationPackages where packageId = $id")){
				$stmt->execute();
				$stmt->store_result();
				$stmt->bind_result($id,$name,$description,$cost,$quantity,$imagePath,$saleCost,$sale);
				
				//fetch rows
				if($stmt->num_rows>0){
					while($stmt->fetch()){
						$data[] = array("id"=>$id,
                                         "name"=>$name,
										 "description"=>$description,
										 "cost"=>$cost,
                                         "quantity"=>$quantity,
                                         "imagePath"=>$imagePath,
                                         "saleCost"=>$saleCost,
                                         "sale"=>$sale);			
					}
				
				}
					
			}//all good
			return $data;	
		
		}//getAllVacationPackages
        
        function insertToCart($name,$description,$cost,$quantity){
		
			$queryString = "insert into Cart(packageName,description,price,Quantity)
				values(?,?,?,?)";
				
			$insertId = "-1";
			if ($stmt=$this->connection->prepare($queryString)){
				$stmt->bind_param("ssii",$name,$description,$cost,$quantity);
				$stmt->execute();
				$stmt->store_result();
				$insertId = $stmt->insert_id;
				
			}
			return $insertId;
		}//add to cart
        
        function addVacationPackages($name,$description,$cost,$quantity,$imagePath,$salePrice,$sale)
        {
            $queryString = "insert into VacationPackages(packageName,description,originalPrice,Quantity,imagePath,salePrice,sale)
				values(?,?,?,?,?,?,?)";
				
			$insertId = "-1";
			if ($stmt=$this->connection->prepare($queryString)){
				$stmt->bind_param("ssiisii",$name,$description,$cost,$quantity,$imagePath,$salePrice,$sale);
				$stmt->execute();
				$stmt->store_result();
				$insertId = $stmt->insert_id;
				
			}
            //echo stmt->execute();
            return $insertId;
        }//add new vacation packages
        
        function getFromCart()
        {
            $data = array();
			
			if ($stmt = $this->connection->prepare("select * from Cart")){
				$stmt->execute();
				$stmt->store_result();
				$stmt->bind_result($id,$name,$description,$cost,$quantity);
				
				
				//fetch rows
				if($stmt->num_rows>0){
					while($stmt->fetch()){
						$data[] = array("id"=>$id,
                                         "name"=>$name,
										 "description"=>$description,
										 "price"=>$cost,
                                         "quantity"=>$quantity,
                                       );		 	
					} 
				}
					
			}//all good
			return $data; 
        }//fetch from cart
        
        function getAllProductsFromCart()
        {
            $data = $this->getFromCart();
			return $data;
			
        }
        
        function deleteFromCart($id)
        {
			$queryString = "delete from Cart";
			$numRows = 0;
			if($stmt = $this->connection->prepare($queryString)) 
            {
				$stmt->execute();
				$stmt->store_result();
				$numRows = $stmt->affected_rows;
			}
			return $numRows;
		}// delete from cart (clear cart)
        
        function checkSaleDeleteConstraint()
        {
            if ($stmt = $this->connection->prepare("select * from VacationPackages where sale = 1"))
			{
			    $stmt->execute();
			    $stmt->store_result();
            }
            if($stmt->num_rows === "3" || $stmt->num_rows < "3")
                return false;
            else if($stmt->num_rows > 3)
                return true;
        } // check for not sale contraint

        function checkSaleAddConstraint()
        {
            if ($stmt = $this->connection->prepare("select * from VacationPackages where sale = 1"))
                {
				    $stmt->execute();
				    $stmt->store_result();
                }
                if($stmt->num_rows === "5"|| $stmt->num_rows > "5")
                    return false;
                else if($stmt->num_rows < 5)
                    return true;
        }//check for add sale constraint
	}//class
	