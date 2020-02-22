<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_SlideShowSimple.ascx.cs" Inherits="LTPL.ICAS.WebApplication.App_UserControls.UC_SlideShowSimple" %>
<script type="text/javascript">
	$(function () {
		$("#slideshow > div:gt(0)").hide();

		setInterval(function () {
			$('#slideshow > div:first')
			.fadeOut(4000)
			.next()
			.fadeIn(4000)
			.end()
			.appendTo('#slideshow');
		}, 5000);

	});
</script>
<style type="text/css">
	#HomepageSlideshow
	{
		/*display: block;
    float: left;
    margin: 0;
    padding: 8px;
    width: 100%;
    height: 300px;
    background-color: Red;
    background-color: Yellow;
    background: url(../Images/COLLEGE-PHOTO-003.JPG) LEFT top no-repeat;
    background-position: bottom center;
    background: url(../Images/TSDC-Alumni-Zone.PnG) LEFT top no-repeat;*/
	}


	/*****************************/

	#slideshow1
	{
		/*
    margin: 15px auto;
        padding: 10px;
    box-shadow: 0 0 20px rgba(0,0,0,0.4);
         */
		position: relative;
		width: 101%;
		height: 350px;
		overflow: hidden;
		background-image: linear-gradient(#04519b, #044687 60%, #033769);
		background-repeat: no-repeat;
		color: white;
		z-index: 1111;
	}

		#slideshow1 img
		{
			width: 100%;
		}

		#slideshow1 > div
		{
			position: absolute;
			top: 0px;
			left: 0px;
			right: 0px;
			bottom: 0px;
		}

		#slideshow1 .caption
		{
			color: rgba(163, 192, 232, 1);
			font-family: Microsoft JhengHei;
			font-size: large;
			padding-top: 8px;
			text-align: center;
			bottom: 0;
		}

			#slideshow1 .caption p
			{
				font-size: 22px;
				font-family: Georgia;
			}
</style>

<div id="slideshow1">
	<div>
		<a href="/photogallery.aspx" title="WEL-COME TO THE WEBSITE OF TSD COLLEGE, B.D.PUR (SASAN), GANJAM, ODISHA" target="_blank">
			<img src="Images/slides_tsdc/slide_2017_1.jpg" class="img-responsive" data-caption="HEARTY WEL-COME" alt="HEARTY WEL-COME TO OUR COLLEGE WEBSITE" />
		</a>
		<div class="caption">
			<p>MOST WELCOME TO THE WEBSITE OF OUR COLLEGE</p>
		</div>
	</div>
	<div>
		<a href="#" title="COLLEGE LIBARY: LET YOU HELP TO IMPROVE YOUR READING HABIT" target="_blank">
			<img src="../Images/slides_tsdc/slide_2017_7_NSS.jpg" alt="" data-caption="COLLEGE LIBARY: LET YOU HELP TO IMPROVE YOUR READING HABIT" />
		</a>
		<div class="caption">
			<p>National Service Scheme (NSS) </p>
		</div>
	</div>
	<div>
		<a href="/photogallery.aspx" title=" ODIA SAHITYA SAMAJA CELEBRATION BY STUDENTS & STAFFS" target="_blank">
			<img src="../Images/slides_tsdc/slide_04.jpg" alt="ODIA SAHITYA SAMAJA CELEBRATION BY STUDENTS & STAFFS" data-caption=" ODIA SAHITYA SAMAJA CELEBRATION BY STUDENTS & STAFFS" />
		</a>
		<div class="caption">
			<p>ODIA SAHITYA SAMAJA CELEBRATION BY STUDENTS & STAFFS</p>
		</div>
	</div>
	<%-- 
	<div>
		<a href="#" title="RED RIBOON CLUB OF THE COLLEGE & SEMINARS BEING DONE IN COLLEGE BY HISTORY DEPT." target="_blank">
			<img src="../Images/slides_tsdc/slide_05.jpg" alt data-caption="RED RIBOON CLUB OF THE COLLEGE & SEMINARS BEING DONE IN COLLEGE BY HISTORY DEPT." />
		</a>
		<div class="caption">
			<p>RED RIBOON CLUB OF THE COLLEGE & SEMINARS BEING DONE IN COLLEGE BY HISTORY DEPT.</p>
		</div>
	</div>
	<div>
		<a href="#" title="NEW BULDING CREATED IN RECENT PAST.. FOR IT EDUCATION TO STUDENTS" target="_blank">
			<img src="../Images/slides_tsdc/slide_07.jpg" alt data-caption="NEW BULDING CREATED IN RECENT PAST.. FOR IT EDUCATION TO STUDENTS" />
		</a>
		<div class="caption">
			<p>NEW BULDING CREATED IN RECENT PAST.. FOR IT EDUCATION TO STUDENTS</p>
		</div>
	</div>
	<div>
		<a href="/photogallery.aspx" title="ADMINISTRATIVE BUILDING & STAFFS" target="_blank">
			<img src="../Images/slides_tsdc/slide_0002.jpg" alt data-caption="ADMINISTRATIVE BUILDING & STAFFS OF TSD COLLEGE" />
		</a>
		<div class="caption">
			<p>ADMINISTRATIVE BUILDING AND SOME OF THE STAFFS OF THE COLLEGE</p>
		</div>
	</div>
	
	   <div>
        <a href="/photogallery.aspx" title=" STAFF COLLAGE OF THE TSD COLLEGE" target="_blank">
            <img src="../Images/slides_tsdc/tsdc-slide-001.jpg" alt data-caption=" STAFF COLLAGE OF THE TSD COLLEGE" />
        </a>
        <div class="caption">
            <p>STAFF COLLAGE OF THE TSD COLLEGE</p>
        </div>
    </div>
    <div>
        <a href="/photogallery.aspx" title="WEL-COME TO THE WEBSITE OF TSD COLLEGE, B.D.PUR (SASAN), GANJAM, ODISHA" target="_blank">
            <img src="../Images/slides_tsdc/slide_000.jpg" alt data-caption="WEL-COME TO THE WEBSITE OF TSD COLLEGE, B.D.PUR (SASAN), GANJAM, ODISHA" />
        </a>
        <div class="caption">
            <p>OUR REVERED PRINCIPAL THANKS YOU FOR VISITING OUR WEBSITE</p>
        </div>
    </div>
    <div>
        <a href="/photogallery.aspx" title="NCC WING OF THE COLLEGE" target="_blank">
            <img src="../Images/slides_tsdc/slide_07.jpg" alt data-caption="NCC WING OF THE COLLEGE" />
        </a>
        <div class="caption">
            <p>NCC WING OF THE TSD COLLEGE</p>
        </div>
    </div>
	 <div>
        <a href="/photogallery.aspx" title="NEW ADMINISTRATIVE BUILDING OF TSD COLLEGE" target="_blank">
            <img src="../Images/slides_tsdc/slide_00.jpg" alt data-caption="NEW ADMINISTRATIVE BUILDING OF TSD COLLEGE" />
        </a>
        <div class="caption">
            <p>NEW ADMINISTRATIVE BUILDING OF TSD COLLEGE</p>
        </div>
    </div> 
	<div>
        <a href="#" title="YOUTH RED CROSS - STUDENTS & STAFF FOR THE ACTIVITY" target="_blank">
            <img src="../Images/slides_tsdc/slide_01.jpg" alt data-caption="... & YOUTH RED CROSS - STUDENTS & STAFF FOR THE ACTIVITY" />
        </a>
        <div class="caption">
            <p>YOUTH RED CROSS - STUDENTS & STAFF FOR THE ACTIVITY</p>
        </div>
    </div>
	--%>
</div>


