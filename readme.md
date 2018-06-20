# 12 Factor Application Demo

This is the demo repository to go along with my NDC Oslo 2018 talk "12 Factor Microservices".  The slides are [available here](https://andydote.co.uk/presentations/twelve-factor) (press S to get speaker notes!)

## Running

If you want to run this, you really need Docker installed.  I've tested this under git-for-window's bash prompt using Docker For Windows (Hyper-V).

1. Run `./tools/start.sh`
2. Open a Windows command prompt, and run `run.bat`<br />
  You have to run it from windows cmd as there seems to be a line-ending issue when piping output from dotnet -> filebeat under git bash.
3. back in Bash, send an api request:
  ```bash
  curl -X POST --data '{}' http://localhost:5000/events/store
  ```
4. open Kibana (http://localhost:5601) and check out your logs!
5. When you're done, run `./tools/stop.sh`

## Structure

There is a branch for the addition of each factor (which has valid code changes.)  You can run this to see the relevant branches:

```bash
git branch -a | grep factor-
```
