#!/usr/bin/expect

# Deploy seeder
spawn -noecho sh -c "scp -r -o StrictHostKeyChecking=no -P $env(AWS_PORT) PayBitForward/Seeder/bin/Release/* $env(AWS_USER)@$env(AWS_HOST):~/seeder"

expect {
  "password:" { send "$env(AWS_PASS)\r" }
}

expect eof

# Deploy client
spawn -noecho sh -c "scp -r -o StrictHostKeyChecking=no -P $env(AWS_PORT) PayBitForward/Client/bin/Release/* $env(AWS_USER)@$env(AWS_HOST):~/client"

expect {
  "password:" { send "$env(AWS_PASS)\r" }
}

expect eof

