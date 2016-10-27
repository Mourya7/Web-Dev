<?php

class VacationPackage{
    private $packageId;
    private $imagePath;
    private $packageName;
    private $description;
    private $cost;
    private $sale;


    function getPackageName()
    {
        return $this->packageName;
    }

    function getPackageId()
    {
        return $this->packageId;
    }

    function getImagePath()
    {
        return $this->imagePath;
    }

    function getDescription()
    {
        return $this->description;
    }

    function getCost()
    {
        return $this->cost;
    }

    function getSale()
    {
        return $this->sale;
    }
}

?>
