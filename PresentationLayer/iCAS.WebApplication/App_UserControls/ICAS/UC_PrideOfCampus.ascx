<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_PrideOfCampus.ascx.cs" Inherits="TCon.iCAS.WebApplication.App_UserControls.ICAS.UC_PrideOfCampus" %>
<style type="text/css">
    @media only screen and (max-device-width: 480px)
    {

        #StudentZone, #Div_Student
        {
            min-height: 220px;
        }

        #WebZones #Div_Student,
        #WebZones #Div_Staff
        {
            margin: 5px 0px;
            overflow: hidden;
            display: block;
            width: 100%;
            min-height: 220px;
        }

            #ctrl_StudentZone_ulctrl_AskLoginStudent,
            #WebZones #Div_Student > ul,
            #WebZones #Div_Staff ul,
            .AskLoginStudent
            {
                width: 100%;
                list-style-type: none;
                margin: 0;
                padding: 0;
            }

        .AskLoginStudent
        {
            color: blue;
            width: 100%;
            height: 100px;
            display: block;
            float: left;
            margin: 5px 0px;
        }

        .StaffZoneLink100,
        .StudentZoneLink
        {
            display: block;
            float: left;
            width: 99%;
            margin: 0px;
            padding: 0px;
            text-align: justify;
            background-color: floralwhite;
        }

        #WebZones #Div_Student ul li
        {
            width: 99%;
            list-style-type: none;
            margin: 0;
            padding: 0;
            padding: 5px 0px;
        }


        #WebZones #Div_Staff ul li
        {
            width: 99%;
            list-style-type: none;
            margin: 1% 0px 0px 0px;
            padding: 0;
            padding: 5px 0px;
        }

        #WebZones #Div_Student ul li.WebpartTitle
        {
            width: 100%;
            margin-bottom: 10px;
        }
    }
</style>

<div id="PrideOfZone" class="col-md-6">
    .....PrideOfZone
</div>
<div id="content-slider" class="row-fluid">
    <div id="slider" class="col-md-12">
        <div id="mask" class="col-md-12">
            <ul>
                <li id="first" class="firstanimation">
                    <a href="photo-gallery">
                        <img src="Images/slides_tsdc/slide_2017_1.jpg" class="img-responsive" alt="WEL-COME TO THE WEBSITE OF TSD COLLEGE" />
                    </a>
                    <div class="tooltip-text">
                        <h1>HEARTY WEL-COME TO TSD COLLEGE WEBSITE</h1>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</div>
