// Classifier Variable
let classifier;
// Model URL
let imageModelURL = './models/ejemplo2/';

// Video
let video;
let flippedVideo;
// To store the classification
let label = "";
let confidence = 0.0;

// Load the model first
function preload() {
  classifier = ml5.imageClassifier(imageModelURL + 'model.json');
}

function setup() {
  createCanvas(320, 260);
  // Create the video
  video = createCapture(VIDEO);
  video.size(320, 240);
  video.hide();

  flippedVideo = ml5.flipImage(video);
  // Start classifying
  classifyVideo();
}

function draw() {
  background(0);
  // Draw the video
  // image(flippedVideo, 0, 0);

  // Draw the label
  fill(255);
  //textSize(16);
  textAlign(CENTER);
  text(label, width / 2, height - 4);
  
  textSize(32);
  textAlign(LEFT);
  //text(confidence, 40, 40);

  if (label == "Hernández") {
    rect(width/2, height/2, 100, 100);
  }

}

// Get a prediction for the current video frame
function classifyVideo() {
  flippedVideo = ml5.flipImage(video)
  classifier.classify(flippedVideo, gotResult);
  flippedVideo.remove();

}

// When we get a result
function gotResult(error, results) {
  // If there is an error
  if (error) {
    console.error(error);
    return;
  }
  // The results are in an array ordered by confidence.
  console.log(results[0]);
  label = results[0].label;
  confidence = results[0].confidence;
  // Classifiy again!

  classifyVideo();
}