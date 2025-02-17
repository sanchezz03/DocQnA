# How to Run the Application

## Task Summary:

This project implements a question-answering system that works with local text documents. 
The system integrates with the Azure OpenAI API to compute embeddings and generate answers based on document relevance.

The task includes the following steps:

### 1. Document Ingestion & Embedding:
Load local text documents (e.g., from a folder) and compute their vector embeddings using the Azure OpenAI embeddings API.

### 2. Question Handling & Similarity Search:
When a user submits a question, compute its embedding and use cosine similarity to identify the most relevant documents.

### 3. Answer Generation:
Combine information from the most relevant documents with the question to generate a prompt. Send this prompt to Azure OpenAI’s completions API to get an answer.

## Requirements:

### - Asynchronous API calls.
### - Clean code with error handling and configuration via environment variables.
### - Simple user interface.
### - Clear documentation for setup and running the project.

## Project Structure:

### The project is divided into 3 layers:

### 1. Presentation Layer
### 2. Application Layer
### 3. Infrastructure Layer

## Steps to Run the Project:

### 1. Download or clone the repository to your local machine.
### 2. Open a terminal in the root of the project and run.
 ````bash
 dotnet restore
````
### 3. To run the console application, execute the following command in the terminal.
 ````bash
dotnet run
````
