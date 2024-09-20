$(document).ready(function () {
    $('.rating').each(function () {
        var rating = parseFloat($(this).text());
        var numStars = Math.round(rating / 2); // Converts a 10-point scale to a 5-star scale
        var stars = '';
        for (var i = 1; i <= 5; i++) {
            stars += i <= numStars ? '&#9733;' : '&#9734;'; // Solid or hollow stars
        }
        $(this).html(stars); // Replace the numeric rating with stars
    });
});
