<script lang="ts">
  import { getContext } from 'svelte';
  import { fade } from 'svelte/transition';

  import { contextKey } from '../app.svelte';
  import Plus from './plus.svelte';
  import RightArrow from './rightArrow.svelte';
  import Remove from './remove.svelte';
  import Back from './back.svelte';

  interface ISection {
    direction: Direction;
    name: string;
    sections: ISection[] | null;
  }

  enum Direction {
    Horizontal = 0,
    Vertical = 1,
  }

  export let section: ISection;
  export let removeSection: (section: ISection) => void;

  let confirmRemove: boolean = false;

  $: if (section) {
    updateValue();
  }

  const { resources, updateValue } = getContext(contextKey);
</script>

<div transition:fade={{ duration: 250 }} class="item root" class:zone={section.sections === null}>
  {#if confirmRemove}
    <div out:fade={{ duration: 250 }} class="group confirmOverlay">
      <div class="background" />
      <div class="button" title={resources['xpandablesection.cancelremove']} on:click={() => (confirmRemove = false)}>
        <Back />
      </div>
      <div class="item text"><b>{resources['xpandablesection.removemessage']}</b></div>
      <div
        class="button destructive"
        title={resources['xpandablesection.confirmremove']}
        on:click={() => removeSection(section)}
      >
        <Remove />
      </div>
    </div>
  {/if}
  <div class="group">
    <div
      class="button"
      title={resources['xpandablesection.add']}
      on:click={() => {
        if (section.sections === null) {
          section.sections = [
            { direction: Direction.Horizontal, name: '', sections: null },
            { direction: Direction.Horizontal, name: '', sections: null },
          ];
        } else {
          section.sections = [...section.sections, { direction: Direction.Horizontal, name: '', sections: null }];
        }
      }}
    >
      <Plus />
    </div>
    <div
      class="button"
      class:disabled={section.sections === null}
      class:down={section.direction === Direction.Vertical}
      title={resources['xpandablesection.direction']}
      on:click={() => {
        if (section.direction === Direction.Horizontal) {
          section.direction = Direction.Vertical;
        } else {
          section.direction = Direction.Horizontal;
        }
      }}
    >
      <RightArrow />
    </div>
    <input class="item" type="text" placeholder={resources['xpandablesection.name']} bind:value={section.name} />
    {#if removeSection !== undefined}
      <div
        class="button destructive"
        title={resources['xpandablesection.remove']}
        on:click={() => (confirmRemove = true)}
      >
        <Remove />
      </div>
    {/if}
  </div>
  <div class="group context" class:column={section.direction === Direction.Vertical}>
    {#if section.sections === null}
      <div class="widgetZone group item">
        <div class="group column item">{resources['xpandablesection.widgetzone']}</div>
      </div>
    {:else}
      {#each section.sections as subSection (subSection)}
        <svelte:self
          section={subSection}
          removeSection={(sectionToDelete) => {
            if (section.sections.length === 2) {
              section.sections = null;
            } else if (section.sections.length > 2) {
              const newSections = [];

              for (const oldSection of section.sections) {
                if (oldSection !== sectionToDelete) {
                  newSections.push(oldSection);
                }
              }

              section.sections = newSections;
            }
          }}
        />
      {/each}
    {/if}
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

  .root {
    min-width: fit-content;
    min-height: fit-content;
    position: relative;
    z-index: 0;
  }

  .confirmOverlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    z-index: 1;
    overflow: hidden;
  }

  .confirmOverlay .background {
    position: absolute;
    right: 1em;
    top: 1em;
    animation: expand 0.8s forwards;
    background: #b12628;
    border-radius: 100vh;
    transform: translate(50%, -50%);
    z-index: -1;
  }

  .confirmOverlay .text {
    align-self: center;
    padding: 0 1em;
    display: -webkit-box;
    -webkit-line-clamp: 3;
    -webkit-box-orient: vertical;
    color: #e5e5e5;
  }

  .confirmOverlay b {
    color: #e5e5e5;
  }

  @keyframes expand {
    0% {
      width: 0vw;
      height: 0vw;
    }

    100% {
      width: 300vw;
      height: 300vw;
    }
  }

  .zone {
    border: 1px dashed #bdbbbb;
  }

  .context {
    min-height: 2em;
    height: calc(100% - 2.4em);
  }

  .button {
    border-radius: 100vh;
    width: 2em;
    height: 2em;
    fill: rgb(61, 61, 61);
    background-color: rgb(194, 199, 207);
    padding: 0.4em;
    margin: 0.2em;
    cursor: pointer;
    transition: 0.4s;
    box-sizing: border-box;
  }

  .button.down {
    transform: rotate(90deg);
  }

  .button:not(.disabled).destructive {
    background-color: #b12628;
    fill: #e5e5e5;
  }

  .button:not(.disabled).destructive:hover {
    background-color: #283f8a;
  }

  .button.disabled {
    cursor: not-allowed;
    color: #696663;
    background-color: #a3a2a2;
    background-image: repeating-linear-gradient(
      -45deg,
      rgba(189, 187, 187, 0) 0,
      #bdbbbb 1px,
      #bdbbbb 2px,
      rgba(189, 187, 187, 0) 3px,
      rgba(189, 187, 187, 0) 4px
    );
  }

  .button:not(.disabled):hover {
    background-color: rgb(161, 169, 182);
  }

  input[type='text'] {
    height: 2em;
    margin: 0.2em;
    padding: 0.1em 0.5em;
    border-radius: 100vh;
    border: 2px solid #a1a9b6;
    background-color: #f3f4f5;
    color: #262524;
    box-sizing: border-box;
    width: 7em;
  }

  input[type='text']:focus {
    border-color: #7d95e3;
    background-color: #fff;
    outline: 0;
  }

  .widgetZone {
    margin: 0.2em;
    border-radius: 1em;
    background: #003e53;
    opacity: 0.3;
    align-items: center;
  }

  .widgetZone .group {
    color: #fff;
    font-size: 1em;
    font-weight: 600;
    text-align: center;
    line-height: 1em;
    text-transform: uppercase;
  }
</style>
