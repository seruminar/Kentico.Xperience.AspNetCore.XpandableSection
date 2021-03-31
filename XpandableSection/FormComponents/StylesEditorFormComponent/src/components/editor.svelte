<script lang="ts">
  import { getContext, onMount } from 'svelte';
  import 'monaco-editor/esm/vs/editor/browser/controller/coreCommands.js';
  import 'monaco-editor/esm/vs/editor/contrib/bracketMatching/bracketMatching.js';
  import 'monaco-editor/esm/vs/editor/contrib/clipboard/clipboard.js';
  import 'monaco-editor/esm/vs/editor/contrib/comment/comment.js';
  import 'monaco-editor/esm/vs/editor/contrib/contextmenu/contextmenu.js';
  import 'monaco-editor/esm/vs/editor/contrib/find/findController.js';
  import 'monaco-editor/esm/vs/editor/contrib/folding/folding.js';
  import 'monaco-editor/esm/vs/editor/contrib/hover/hover.js';
  import 'monaco-editor/esm/vs/editor/contrib/indentation/indentation.js';
  import 'monaco-editor/esm/vs/editor/contrib/links/links.js';
  import 'monaco-editor/esm/vs/editor/contrib/multicursor/multicursor.js';
  import 'monaco-editor/esm/vs/editor/contrib/suggest/suggestController.js';
  import 'monaco-editor/esm/vs/editor/contrib/wordHighlighter/wordHighlighter.js';

  import * as monaco from 'monaco-editor/esm/vs/editor/editor.api.js';

  import 'monaco-editor/esm/vs/basic-languages/css/css.contribution.js';
  import 'monaco-editor/esm/vs/language/css/monaco.contribution.js';

  import { contextKey } from '../app.svelte';

  export let value: string;

  let monacoRoot: HTMLDivElement;
  let editor: monaco.editor.IStandaloneCodeEditor;
  let resizeObserver: ResizeObserver;

  onMount(async () => {
    (window as any).MonacoEnvironment = {
      getWorkerUrl: (moduleId: string, label: string) => {
        if (label === 'css' || label === 'scss' || label === 'less') {
          return '/xpandablesection/css.worker.js';
        }

        return '/xpandablesection/editor.worker.js';
      },
    };

    editor = monaco.editor.create(monacoRoot, {
      value,
      language: 'css',
      tabSize: 2,
      minimap: { enabled: false },
      fixedOverflowWidgets: true,
    });

    editor.onDidChangeModelContent(async () => {
      value = editor.getValue();

      try {
        updateValue(value);
      } catch (error) {
        console.log(error);
      }
    });

    resizeObserver = new ResizeObserver(() => editor.layout());
    resizeObserver.observe(monacoRoot);

    return () => {
      resizeObserver.disconnect();
    };
  });

  const { resources, updateValue } = getContext(contextKey);
</script>

<div class="item root">
  <div class="group">
    <div class="monacoRoot item" bind:this={monacoRoot} />
  </div>
</div>

<style>
  .group {
    display: flex;
  }

  .column {
    flex-direction: column;
  }

  .item {
    flex: 1;
  }

  .monacoRoot {
    height: 20em;
    border-radius: 0.5em;
    border: 2px solid #a1a9b6;
    overflow: hidden;
  }

  .monacoRoot :global(span) {
    font-family: Consolas, 'Courier New', monospace;
  }
</style>
